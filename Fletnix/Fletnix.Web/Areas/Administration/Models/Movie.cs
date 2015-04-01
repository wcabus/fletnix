using System;
using System.ComponentModel.DataAnnotations;

namespace Fletnix.Web.Areas.Administration.Models
{
    public class Movie
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public Guid StreamId { get; set; }

        [Required(AllowEmptyStrings = false), StringLength(256)]
        public string Title { get; set; }

        [UIHint("Synopsis")]
        [DataType(DataType.MultilineText)]
        public string Synopsis { get; set; }

        [Required, DataType(DataType.Duration), Display(Name = "Duration")]
        public TimeSpan Length { get; set; }

        [StringLength(1024), Display(Name = "Image"), DataType(DataType.ImageUrl)]
        [UIHint("Image")]
        public string ImageUri { get; set; }

        
    }
}