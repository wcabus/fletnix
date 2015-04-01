using System.ComponentModel.DataAnnotations;

namespace Fletnix.Web.Areas.Administration.Models
{
    public class GenreSelection
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}