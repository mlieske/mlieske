using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDRepoWebApi.Models.Models
{
    public class DVD
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int RealeaseYear { get; set; }
        public int DirectorId { get; set; }
        public int RatingId { get; set; }
        public string Notes { get; set; }

        public virtual Director DvdDirector { get; set; }
        public virtual Rating DvdRating { get; set; }
    }
}