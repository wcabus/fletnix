using System;
using Fletnix.Domain;

namespace Fletnix.Web.ApiModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string ImageUri { get; set; }
        public TimeSpan Length { get; set; }

        public static Movie FromDomain(MediaStream mediaStream)
        {
            return new Movie
            {
                Id = mediaStream.Id,
                Title = mediaStream.Title,
                Synopsis = mediaStream.Synopsis,
                ImageUri = mediaStream.ImageUri,
                Length = mediaStream.Length
            };
        }
    }
}