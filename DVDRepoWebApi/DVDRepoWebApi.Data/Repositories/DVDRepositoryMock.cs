using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDRepoWebApi.Models;
using DVDRepoWebApi.Models.Interfaces;
using DVDRepoWebApi.Models.Models;

namespace DVDRepoWebApi.Data.Repositories
{
    public class DVDRepositoryMock : IDvdRepository
    {
        private static List<DVD> _DVDList = new List<DVD>();
        private static List<Rating> _RatingList = new List<Rating>();
        private static List<Director> _DirectorList = new List<Director>();

        public DVDRepositoryMock()
        {
            if (!_DirectorList.Any())
            {
                _DirectorList.AddRange(new List<Director>()
                {
                    new Director {DirectorId = 0, DirectorName = "George Lucas" },
                    new Director {DirectorId = 1, DirectorName = "Sam Jones" },
                    new Director {DirectorId = 2, DirectorName = "Joe Smith" }
                });
            }

            if (!_RatingList.Any())
            {
                _RatingList.AddRange(new List<Rating>()
                {
                    new Rating {RatingId = 0, RatingType = "G" },
                    new Rating {RatingId = 1, RatingType = "PG" },
                    new Rating {RatingId = 2, RatingType = "PG-13" },
                    new Rating {RatingId = 3, RatingType = "R" }
                });
            }

            if (!_DVDList.Any())
            {
                _DVDList.AddRange(new List<DVD>()
                {
                    new DVD {DvdId = 0, Title = "A Super Tale", RealeaseYear = 2015,
                    DirectorId = 1, RatingId = 1, Notes = "A great remake!",
                    DvdDirector = _DirectorList.FirstOrDefault(d => d.DirectorId == 1),
                    DvdRating = _RatingList.FirstOrDefault(r => r.RatingId == 1) },

                    new DVD {DvdId = 1, Title = "Star Wars", RealeaseYear = 1977,
                    DirectorId = 0, RatingId = 0, Notes = "Death Star",
                    DvdDirector = _DirectorList.FirstOrDefault(d => d.DirectorId == 0),
                    DvdRating = _RatingList.FirstOrDefault(r => r.RatingId == 0)},

                    new DVD {DvdId = 2, Title = "A Super Tale", RealeaseYear = 1985,
                    DirectorId = 2, RatingId = 1, Notes = "The original!",
                    DvdDirector = _DirectorList.FirstOrDefault(d => d.DirectorId == 2),
                    DvdRating = _RatingList.FirstOrDefault(r => r.RatingId == 1)}
                });
            }

        }

        public List<DvdViewModel> GetAll()
        {
            List<DvdViewModel> _DVDViewList = new List<DvdViewModel>();
            foreach(var dvd in _DVDList)
            {
                DvdViewModel row = new DvdViewModel();
                row.DvdId = dvd.DvdId;
                row.Title = dvd.Title;
                row.Director = dvd.DvdDirector.DirectorName;
                row.Rating = dvd.DvdRating.RatingType;
                row.RealeaseYear = dvd.RealeaseYear;
                row.Notes = dvd.Notes;
                _DVDViewList.Add(row);
            }
            _DVDViewList.Sort((x,y) => x.Title.CompareTo(y.Title));
            return _DVDViewList;
        }

        public DvdViewModel GetById(int id)
        {
            var idDvd = _DVDList.FirstOrDefault(d => d.DvdId == id);
            return (new DvdViewModel(idDvd));
        }

        public List<DvdViewModel> GetByYear(int year)
        {
            List<DvdViewModel> _DVDViewList = new List<DvdViewModel>();
            var result = _DVDList.Where(d => d.RealeaseYear == year);
            foreach(var dvd in result)
            {
                _DVDViewList.Add(new DvdViewModel(dvd));
            }
            return (_DVDViewList);
        }

        public List<DvdViewModel> GetByDirector(string director)
        {
            List<DvdViewModel> _DVDViewList = new List<DvdViewModel>();

            var result = _DVDList.Where(d => d.DvdDirector.DirectorName.Contains(director)).ToList();
            foreach (var dvd in result)
            {
                _DVDViewList.Add(new DvdViewModel(dvd));
            }
            return _DVDViewList;
        }

        public List<DvdViewModel> GetByRating(string rating)
        {
            List<DvdViewModel> _DVDViewList = new List<DvdViewModel>();

            var result = _DVDList.Where(d => d.DvdRating.RatingType == rating).ToList();
            foreach (var dvd in result)
            {
                _DVDViewList.Add(new DvdViewModel(dvd));
            }
            return _DVDViewList;
        }

        public List<DvdViewModel> GetByTitle(string title)
        {
            List<DvdViewModel> _DVDViewList = new List<DvdViewModel>();

            var result = _DVDList.Where(d => d.Title.Contains(title)).ToList();
            foreach (var dvd in result)
            {
                dvd.DvdDirector.DirectorName = _DirectorList.FirstOrDefault(d => d.DirectorId == dvd.DirectorId).DirectorName;
                dvd.DvdRating.RatingType = _RatingList.FirstOrDefault(r => r.RatingId == dvd.RatingId).RatingType;
                _DVDViewList.Add(new DvdViewModel(dvd));
            }
            return _DVDViewList;

        }

        public DvdViewModel Create(DvdViewModel dvd)
        {
            DVD newDvd = new DVD();
            var getRating = GetRating(dvd);
            var getDirector = GetDirector(dvd);
            int newId = _DVDList.Max(d => d.DvdId) + 1;

            newDvd.DvdId = newId;
            newDvd.Title = dvd.Title;
            newDvd.RatingId = getRating.RatingId;
            newDvd.DirectorId = getDirector.DirectorId;
            newDvd.DvdRating = getRating;
            newDvd.DvdDirector = getDirector;
            newDvd.RealeaseYear = dvd.RealeaseYear;
            newDvd.Notes = dvd.Notes;

            _DVDList.Add(newDvd);
            return new DvdViewModel(newDvd);
        }

        private Director GetDirector(DvdViewModel dvd)
        {
            var director = _DirectorList.FirstOrDefault(d => d.DirectorName == dvd.Director);
            if (director == null)
            {
                Director newDirector = new Director();
                var newId = _DirectorList.Max(d => d.DirectorId) + 1;
                newDirector.DirectorId = newId;
                newDirector.DirectorName = dvd.Director;
                _DirectorList.Add(newDirector);
                return newDirector;
            }
            else return director;
        }

        private Rating GetRating(DvdViewModel dvd)
        {
            var rating = _RatingList.FirstOrDefault(d => d.RatingType == dvd.Rating);
            if (rating == null)
            {
                Rating newRating = new Rating();
                var newId = _RatingList.Max(d => d.RatingId) + 1;
                newRating.RatingId = newId;
                newRating.RatingType = dvd.Rating;
                _RatingList.Add(newRating);
                return newRating;
            }
            else return rating;
        }

        public void Delete(int id)
        {
            _DVDList.RemoveAll(d => d.DvdId == id);
        }

        public void Update(int id, DvdViewModel dvd)
        {

            _DVDList.RemoveAll(d => d.DvdId == id);

            DVD newDvd = new DVD();
            var getRating = GetRating(dvd);
            var getDirector = GetDirector(dvd);

            newDvd.DvdId = id;
            newDvd.Title = dvd.Title;
            newDvd.RatingId = getRating.RatingId;
            newDvd.DvdRating = getRating;
            newDvd.DvdDirector = getDirector;
            newDvd.DirectorId = getDirector.DirectorId;
            newDvd.RealeaseYear = dvd.RealeaseYear;
            newDvd.Notes = dvd.Notes;

            _DVDList.Add(newDvd);
            
        }
    }
}