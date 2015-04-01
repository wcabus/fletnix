using System.ComponentModel.DataAnnotations;

namespace Fletnix.Web.Areas.Administration.Models
{
    public class CelebrityEditor
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(128)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, StringLength(128)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [StringLength(16)]
        [Display(Name = "IMDB ID")]
        public string ImdbId { get; set; }

        [StringLength(512)]
        [Display(Name = "Image")]
        [DataType(DataType.ImageUrl)]
        [UIHint("Image")]
        public string ImageUri { get; set; }

        public Domain.Celebrity ToDomain()
        {
            return new Domain.Celebrity
            {
                FirstName = FirstName,
                LastName = LastName,
                ImdbId = ImdbId,
                ImageUri = ImageUri
            };
        }
    }
}