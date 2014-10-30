using System;
using System.IO;
using System.Web;

namespace Fletnix.Web.Results
{
    /// <summary>
    /// Sends the contents of a file to the range response.
    /// 
    /// </summary>
    public class RangeFilePathResult : RangeFileResult
    {
        private const int BufferSize = 4096;

        /// <summary>
        /// Initializes a new instance of the RangeFilePathResult class.
        /// 
        /// </summary>
        /// <param name="contentType">The content type to use for the response.</param><param name="fileName">The file name to use for the response.</param><param name="modificationDate">The file modification date to use for the response.</param><param name="fileLength">The file length to use for the response.</param>
        /// <remarks>
        /// The <paramref name="modificationDate"/> parameter is used internally while creating ETag and Last-Modified headers. Those headers might by used by client in order to verify that the same entity is being requested in separated partial requests and for caching purposes. Because of that it is important that the value passed to this parameter is consitant and reflects the actual state of entity during its entire lifetime.
        /// 
        /// </remarks>
        public RangeFilePathResult(string contentType, string fileName, DateTime modificationDate, long fileLength)
            : base(contentType, fileName, modificationDate, fileLength)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
        }

        /// <summary>
        /// Writes the entire file to the response.
        /// 
        /// </summary>
        /// <param name="response">The response from context within which the result is executed.</param>
        protected override void WriteEntireEntity(HttpResponseBase response)
        {
            response.TransmitFile(this.FileName);
        }

        /// <summary>
        /// Writes the file range to the response.
        /// 
        /// </summary>
        /// <param name="response">The response from context within which the result is executed.</param><param name="rangeStartIndex">Range start index</param><param name="rangeEndIndex">Range end index</param>
        protected override void WriteEntityRange(HttpResponseBase response, long rangeStartIndex, long rangeEndIndex)
        {
            using (FileStream fileStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read))
            {
                fileStream.Seek(rangeStartIndex, SeekOrigin.Begin);
                int num = Convert.ToInt32(rangeEndIndex - rangeStartIndex) + 1;
                byte[] buffer = new byte[BufferSize];
                while (num > 0)
                {
                    int count = fileStream.Read(buffer, 0, BufferSize < num ? BufferSize : num);
                    response.OutputStream.Write(buffer, 0, count);
                    num -= count;
                }
                fileStream.Close();
            }
        }
    }
}