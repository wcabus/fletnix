using System.Collections;
using System.Collections.Generic;

namespace Fletnix.Web.Areas.Administration.Models
{
    public class GenreModel
    {
        public ICollection<GenreSelection> Genres { get; set; }
    }
}