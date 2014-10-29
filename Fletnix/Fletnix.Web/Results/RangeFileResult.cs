using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Fletnix.Web.Results
{
    /// <summary>
    /// Represents a base class that is used to send binary file content to the range response.
    /// 
    /// </summary>
    public abstract class RangeFileResult : ActionResult
    {
        private static char[] _commaSplitArray = new char[1]
    {
      ','
    };
        private static char[] _dashSplitArray = new char[1]
    {
      '-'
    };
        private static string[] _httpDateFormats = new string[3]
    {
      "r",
      "dddd, dd-MMM-yy HH':'mm':'ss 'GMT'",
      "ddd MMM d HH':'mm':'ss yyyy"
    };

        const int BufferSize = 64 * 1024;

        /// <summary>
        /// Gets the content type to use for the response.
        /// 
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// Gets the file name to use for the response.
        /// 
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the file modification date to use for the response.
        /// 
        /// </summary>
        public DateTime FileModificationDate { get; private set; }

        private DateTime HttpModificationDate { get; set; }

        /// <summary>
        /// Gets the file length to use for the response.
        /// 
        /// </summary>
        public long FileLength { get; private set; }

        private string EntityTag { get; set; }

        private long[] RangesStartIndexes { get; set; }

        private long[] RangesEndIndexes { get; set; }

        private bool RangeRequest { get; set; }

        private bool MultipartRequest { get; set; }

        static RangeFileResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RangeFileResult class.
        /// 
        /// </summary>
        /// <param name="contentType">The content type to use for the response.</param><param name="fileName">The file name to use for the response.</param><param name="modificationDate">The file modification date to use for the response.</param><param name="fileLength">The file length to use for the response.</param>
        /// <remarks>
        /// The <paramref name="modificationDate"/> parameter is used internally while creating ETag and Last-Modified headers. Those headers might by used by client in order to verify that the same entity is being requested in separated partial requests and for caching purposes. Because of that it is important that the value passed to this parameter is consitant and reflects the actual state of entity during its entire lifetime.
        /// 
        /// </remarks>
        protected RangeFileResult(string contentType, string fileName, DateTime modificationDate, long fileLength)
        {
            if (string.IsNullOrEmpty(contentType))
                throw new ArgumentNullException("contentType");
            this.ContentType = contentType;
            this.FileName = fileName;
            this.FileModificationDate = modificationDate;
            this.HttpModificationDate = modificationDate.ToUniversalTime();
            this.HttpModificationDate = new DateTime(this.HttpModificationDate.Year, this.HttpModificationDate.Month, this.HttpModificationDate.Day, this.HttpModificationDate.Hour, this.HttpModificationDate.Minute, this.HttpModificationDate.Second, DateTimeKind.Utc);
            this.FileLength = fileLength;
        }

        /// <summary>
        /// Generates the entity tag for file
        /// 
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <returns/>
        protected virtual string GenerateEntityTag(ControllerContext context)
        {
            return Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(string.Format("{0}|{1}", (object)this.FileName, (object)this.FileModificationDate))));
        }

        /// <summary>
        /// Writes the entire file to the response.
        /// 
        /// </summary>
        /// <param name="response">The response from context within which the result is executed.</param>
        protected abstract void WriteEntireEntity(HttpResponseBase response);

        /// <summary>
        /// Writes the file range to the response.
        /// 
        /// </summary>
        /// <param name="response">The response from context within which the result is executed.</param><param name="rangeStartIndex">Range start index</param><param name="rangeEndIndex">Range end index</param>
        protected abstract void WriteEntityRange(HttpResponseBase response, long rangeStartIndex, long rangeEndIndex);

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the ActionResult class. (Overrides ActionResult.ExecuteResult(ControllerContext).)
        /// 
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            this.EntityTag = this.GenerateEntityTag(context);
            this.GetRanges(context.HttpContext.Request);
            if (!this.ValidateRanges(context.HttpContext.Response) || !this.ValidateModificationDate(context.HttpContext.Request, context.HttpContext.Response) || !this.ValidateEntityTag(context.HttpContext.Request, context.HttpContext.Response))
                return;
            context.HttpContext.Response.AddHeader("Last-Modified", this.HttpModificationDate.ToString("r"));
            context.HttpContext.Response.AddHeader("ETag", string.Format("\"{0}\"", (object)this.EntityTag));
            context.HttpContext.Response.AddHeader("Accept-Ranges", "bytes");
            if (!this.RangeRequest)
            {
                context.HttpContext.Response.AddHeader("Content-Length", this.FileLength.ToString());
                context.HttpContext.Response.ContentType = this.ContentType;
                context.HttpContext.Response.StatusCode = 200;
                if (context.HttpContext.Request.HttpMethod.Equals("HEAD"))
                    return;
                this.WriteEntireEntity(context.HttpContext.Response);
            }
            else
            {
                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                context.HttpContext.Response.AddHeader("Content-Length", this.GetContentLength(boundary).ToString());
                if (!this.MultipartRequest)
                {
                    context.HttpContext.Response.AddHeader("Content-Range", string.Format("bytes {0}-{1}/{2}", (object)this.RangesStartIndexes[0], (object)this.RangesEndIndexes[0], (object)this.FileLength));
                    context.HttpContext.Response.ContentType = this.ContentType;
                }
                else
                    context.HttpContext.Response.ContentType = string.Format("multipart/byteranges; boundary={0}", (object)boundary);
                context.HttpContext.Response.StatusCode = 206;
                if (context.HttpContext.Request.HttpMethod.Equals("HEAD"))
                    return;
                for (int index = 0; index < this.RangesStartIndexes.Length; ++index)
                {
                    if (this.MultipartRequest)
                    {
                        context.HttpContext.Response.Write(string.Format("--{0}\r\n", (object)boundary));
                        context.HttpContext.Response.Write(string.Format("Content-Type: {0}\r\n", (object)this.ContentType));
                        context.HttpContext.Response.Write(string.Format("Content-Range: bytes {0}-{1}/{2}\r\n\r\n", (object)this.RangesStartIndexes[index], (object)this.RangesEndIndexes[index], (object)this.FileLength));
                    }
                    if (!context.HttpContext.Response.IsClientConnected)
                        return;
                    this.WriteEntityRange(context.HttpContext.Response, this.RangesStartIndexes[index], this.RangesEndIndexes[index]);
                    if (this.MultipartRequest)
                        context.HttpContext.Response.Write("\r\n");
                }
                if (!this.MultipartRequest)
                    return;
                context.HttpContext.Response.Write(string.Format("--{0}--", (object)boundary));
            }
        }

        private string GetHeader(HttpRequestBase request, string header, string defaultValue = "")
        {
            if (!string.IsNullOrEmpty(request.Headers[header]))
                return request.Headers[header].Replace("\"", string.Empty);
            else
                return defaultValue;
        }

        private void GetRanges(HttpRequestBase request)
        {
            string header1 = this.GetHeader(request, "Range", "");
            string header2 = this.GetHeader(request, "If-Range", this.EntityTag);
            DateTime result;
            bool flag = DateTime.TryParseExact(header2, RangeFileResult._httpDateFormats, (IFormatProvider)null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result);
            if (string.IsNullOrEmpty(header1) || !flag && header2 != this.EntityTag || flag && this.HttpModificationDate > result)
            {
                this.RangesStartIndexes = new long[1];
                this.RangesEndIndexes = new long[1] { this.FileLength - 1L };
                this.RangeRequest = false;
                this.MultipartRequest = false;
            }
            else
            {
                string[] strArray1 = header1.Replace("bytes=", string.Empty).Split(RangeFileResult._commaSplitArray);
                this.RangesStartIndexes = new long[strArray1.Length];
                this.RangesEndIndexes = new long[strArray1.Length];
                this.RangeRequest = true;
                this.MultipartRequest = strArray1.Length > 1;
                for (int index = 0; index < strArray1.Length; ++index)
                {
                    string[] strArray2 = strArray1[index].Split(RangeFileResult._dashSplitArray);
                    this.RangesEndIndexes[index] = !string.IsNullOrEmpty(strArray2[1]) ? long.Parse(strArray2[1]) : this.FileLength - 1L;
                    if (string.IsNullOrEmpty(strArray2[0]))
                    {
                        this.RangesStartIndexes[index] = this.FileLength - this.RangesEndIndexes[index];
                        this.RangesEndIndexes[index] = this.FileLength - 1L;
                    }
                    else
                    {
                        RangesStartIndexes[index] = long.Parse(strArray2[0]);
                        RangesEndIndexes[index] = RangesStartIndexes[index] + BufferSize;

                        if (RangesEndIndexes[index] > FileLength - 1)
                            RangesEndIndexes[index] = FileLength - 1;
                    }
                }
            }
        }

        private int GetContentLength(string boundary)
        {
            int num = 0;
            for (int index = 0; index < this.RangesStartIndexes.Length; ++index)
            {
                num += Convert.ToInt32(this.RangesEndIndexes[index] - this.RangesStartIndexes[index]) + 1;
                if (this.MultipartRequest)
                    num += boundary.Length + this.ContentType.Length + this.RangesStartIndexes[index].ToString().Length + this.RangesEndIndexes[index].ToString().Length + this.FileLength.ToString().Length + 49;
            }
            if (this.MultipartRequest)
                num += boundary.Length + 4;
            return num;
        }

        private bool ValidateRanges(HttpResponseBase response)
        {
            if (this.FileLength > (long)int.MaxValue)
            {
                response.StatusCode = 413;
                return false;
            }
            else
            {
                for (int index = 0; index < this.RangesStartIndexes.Length; ++index)
                {
                    if (this.RangesStartIndexes[index] > this.FileLength - 1L || this.RangesEndIndexes[index] > this.FileLength - 1L || (this.RangesStartIndexes[index] < 0L || this.RangesEndIndexes[index] < 0L) || this.RangesEndIndexes[index] < this.RangesStartIndexes[index])
                    {
                        response.StatusCode = 400;
                        return false;
                    }
                }
                return true;
            }
        }

        private bool ValidateModificationDate(HttpRequestBase request, HttpResponseBase response)
        {
            string header1 = this.GetHeader(request, "If-Modified-Since", "");
            if (!string.IsNullOrEmpty(header1))
            {
                DateTime result;
                DateTime.TryParseExact(header1, RangeFileResult._httpDateFormats, (IFormatProvider)null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result);
                if (this.HttpModificationDate <= result)
                {
                    response.StatusCode = 304;
                    return false;
                }
            }
            string header2 = this.GetHeader(request, "If-Unmodified-Since", this.GetHeader(request, "Unless-Modified-Since", ""));
            if (!string.IsNullOrEmpty(header2))
            {
                DateTime result;
                DateTime.TryParseExact(header2, RangeFileResult._httpDateFormats, (IFormatProvider)null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result);
                if (this.HttpModificationDate > result)
                {
                    response.StatusCode = 412;
                    return false;
                }
            }
            return true;
        }

        private bool ValidateEntityTag(HttpRequestBase request, HttpResponseBase response)
        {
            string header1 = this.GetHeader(request, "If-Match", "");
            if (!string.IsNullOrEmpty(header1) && header1 != "*")
            {
                string[] strArray = header1.Split(RangeFileResult._commaSplitArray);
                int index = 0;
                while (index < strArray.Length && !(this.EntityTag == strArray[index]))
                    ++index;
                if (index >= strArray.Length)
                {
                    response.StatusCode = 412;
                    return false;
                }
            }
            string header2 = this.GetHeader(request, "If-None-Match", "");
            if (!string.IsNullOrEmpty(header2))
            {
                if (header2 == "*")
                {
                    response.StatusCode = 412;
                    return false;
                }
                else
                {
                    foreach (string str in header2.Split(RangeFileResult._commaSplitArray))
                    {
                        if (this.EntityTag == str)
                        {
                            response.AddHeader("ETag", string.Format("\"{0}\"", (object)str));
                            response.StatusCode = 304;
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}