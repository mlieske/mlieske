using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDRepoWebApi.Models;
using DVDRepoWebApi.Models.Models;
using DVDRepoWebApi.Models.Interfaces;

namespace DVDRepoWebApi.Data.Repositories
{
    public class DVDRepositoryEF : IDvdRepository
    {
        private List<DvdViewModel> _list = new List<DvdViewModel>();
        DVDCatalogEntities efRepo = new DVDCatalogEntities();

        public List<DvdViewModel> GetAll()
        {
            var model = efRepo.DVDs.OrderBy(d => d.Title).ToList();
            foreach(var dvd in model)
            {
                _list.Add(new DvdViewModel(dvd));
            }
            return _list;
        }

        public DvdViewModel GetById(int id)
        {
            var model = efRepo.DVDs.FirstOrDefault(d => d.DvdId == id);
            return new DvdViewModel(model);
        }

        public List<DvdViewModel> GetByDirector(string director)
        {
            var model = efRepo.DVDs.Where(d => d.DvdDirector.DirectorName == director).ToList();
            foreach (var dvd in model)
            {
                _list.Add(new DvdViewModel(dvd));
            }
            return _list;
        }

        public List<DvdViewModel> GetByRating(string rating)
        {
            var model = efRepo.DVDs.Where(d => d.DvdRating.RatingType == rating).ToList();
            foreach (var dvd in model)
            {
                _list.Add(new DvdViewModel(dvd));
            }
            return _list;
        }

        public List<DvdViewModel> GetByTitle(string title)
        {
            var model = efRepo.DVDs.Where(d => d.Title.Contains(title)).ToList().ToList();
            foreach (var dvd in model)
            {
                _list.Add(new DvdViewModel(dvd));
            }
            return _list;

        }

        public List<DvdViewModel> GetByYear(int year)
        {
            var model = efRepo.DVDs.Where(d => d.RealeaseYear == year).ToList();
            foreach (var dvd in model)
            {
                _list.Add(new DvdViewModel(dvd));
            }
            return _list;
        }

        public DvdViewModel Create(DvdViewModel dvd)
        {
            var director = GetDirectorByName(dvd.Director);
            var rating = GetRatingByName(dvd.Rating);
            DVD newDvd = new DVD();

            newDvd.Title = dvd.Title;
            newDvd.DirectorId = director.DirectorId;
            newDvd.RatingId = rating.RatingId;
            newDvd.RealeaseYear = dvd.RealeaseYear;
            newDvd.DvdRating = rating;
            newDvd.DvdDirector = director;
            newDvd.Notes = dvd.Notes;

            efRepo.DVDs.Add(newDvd);
            efRepo.SaveChanges();

            var max = efRepo.DVDs.Max(i => i.DvdId);
//            var model = GetById(max);
            var model = efRepo.DVDs.FirstOrDefault(d => d.DvdId == max);
            return new DvdViewModel(model);
        }

        private Rating GetRatingByName(string rating)
        {
            var getRating = efRepo.Ratings.FirstOrDefault(d => d.RatingType == rating);
            if (getRating == null)
            {
                Rating newRating = new Rating();
                var newId = efRepo.Ratings.Max(d => d.RatingId) + 1;
                newRating.RatingId = newId;
                newRating.RatingType = rating;
                efRepo.Ratings.Add(newRating);
                efRepo.SaveChanges();
                return newRating;
            }
            else return getRating;
        }

        private Director GetDirectorByName(string director)
        {
            var getDirector = efRepo.Directors.FirstOrDefault(d => d.DirectorName == director);
            if (getDirector == null)
            {
                Director newDirector = new Director();
                var newId = efRepo.Directors.Max(d => d.DirectorId) + 1;
                newDirector.DirectorId = newId;
                newDirector.DirectorName = director;
                efRepo.Directors.Add(newDirector);
                efRepo.SaveChanges();
                return newDirector;
            }
            else return getDirector;
        }

        public void Delete(int id)
        {
            var model = efRepo.DVDs.FirstOrDefault(d => d.DvdId == id);
            efRepo.DVDs.Remove(model);
            efRepo.SaveChanges();
        }

        public void Update(int id, DvdViewModel dvd)
        {
            var model = efRepo.DVDs.FirstOrDefault(d => d.DvdId == id);
            var director = GetDirectorByName(dvd.Director);
            var rating = GetRatingByName(dvd.Rating);
            model.DvdId = id;
            model.Title = dvd.Title;
            model.DirectorId = director.DirectorId;
            model.RatingId = rating.RatingId;
            model.RealeaseYear = dvd.RealeaseYear;
            model.DvdRating = rating;
            model.DvdDirector = director;
            model.Notes = dvd.Notes;
            efRepo.SaveChanges();
        }
    }
}