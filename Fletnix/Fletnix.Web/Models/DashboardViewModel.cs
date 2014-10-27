using System.Collections.Generic;
using Fletnix.Domain;

namespace Fletnix.Web.Models
{
    public class DashboardViewModel
    {
        public List<MediaStream> Movies { get; set; }
        public List<TvShow> TvShows { get; set; }
    }
}