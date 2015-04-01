using System.Collections.Generic;

namespace Fletnix.Web.Areas.Administration.Models
{
    public class MovieDetails
    {
        public Movie Movie { get; set; }
        public ICollection<GenreSelection> Genres { get; set; }
    }
}