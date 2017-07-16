using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDRepoWebApi.Models.Models
{
    public class DvdViewModel
    {
        public int? DvdId { get; set; }
        public string Title { get; set; }
        public int RealeaseYear { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Notes { get; set; }

        public DvdViewModel() { }

        public DvdViewModel(DVD dvd)
        {
            DvdId = dvd.DvdId;
            Title = dvd.Title;
            RealeaseYear = dvd.RealeaseYear;
            Rating = dvd.DvdRating.RatingType;
            Director = dvd.DvdDirector.DirectorName;
            Notes = dvd.Notes;
        }
    }

}