using DVDRepoWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDRepoWebApi.Models;

namespace Data.Repositories
{
    public class DVDRepositoryMock : IDvdRepository
    {
        private static List<DVD> _DVDList;

        static DVDRepositoryMock()
        {
            _DVDList = new List<DVD>
            {
                new DVD {DvdId = 0, Title = "A Super Tale", ReleaseYear = 2015,
                Director = "Sam Jones", Rating = "PG", Notes = "A great remake!" },

                new DVD {DvdId = 1, Title = "A Super Tale", ReleaseYear = 1985,
                Director = "Joe Smith", Rating = "PG", Notes = "The original!"}
            };
        }

        public DVD Create(DVD dvd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DVD> GetAll()
        {
            return _DVDList;
        }

        public List<DVD> GetByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public DVD GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DVD> GetByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<DVD> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<DVD> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        public void Update(DVD dvd)
        {
            throw new NotImplementedException();
        }
    }
}