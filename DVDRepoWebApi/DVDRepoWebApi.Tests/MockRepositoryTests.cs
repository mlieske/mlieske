using DVDRepoWebApi.Data.Repositories;
using DVDRepoWebApi.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDRepoWebApi.Tests
{
    [TestFixture]
    public class MockRepositoryTests
    {
        DVDRepositoryMock repo = new DVDRepositoryMock();

        [Test]
        public void GetAllTest()
        {
            List<DvdViewModel> response = new List<DvdViewModel>();
            response = repo.GetAll();

            Assert.AreEqual(3, response.Count());
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        //[TestCase(4,0)]
        public void GetByIdTest(int searchId, int idReturned)
        {
            DvdViewModel response = new DvdViewModel();
            response = repo.GetById(searchId);

            Assert.AreEqual(idReturned, response.DvdId);
        }

        [TestCase("Star Wars", 1)]
        [TestCase("A Super Tale", 2)]
        [TestCase("NoMovie", 0)]
        public void GetByTitle(string title, int noOfRecords)
        {
            List<DvdViewModel> response = new List<DvdViewModel>();
            response = repo.GetByTitle(title);

            Assert.AreEqual(noOfRecords, response.Count());
        }

        [TestCase("PG", 2)]
        [TestCase("G", 1)]
        [TestCase("PG-13", 0)]
        public void GetByRating(string rating, int noOfRecords)
        {
            List<DvdViewModel> response = new List<DvdViewModel>();
            response = repo.GetByRating(rating);

            Assert.AreEqual(noOfRecords, response.Count());
        }

        [TestCase("Jones", 1)]
        [TestCase("Johnson", 0)]
        public void GetByDirector(string searchString, int noOfRecords)
        {
            List<DvdViewModel> response = new List<DvdViewModel>();
            response = repo.GetByDirector(searchString);

            Assert.AreEqual(noOfRecords, response.Count());
        }

        [TestCase(1985, 1)]
        [TestCase(2010, 0)]
        public void GetByYear(int searchString, int noOfRecords)
        {
            List<DvdViewModel> response = new List<DvdViewModel>();
            response = repo.GetByYear(searchString);

            Assert.AreEqual(noOfRecords, response.Count());
        }

        [Test]
        public void AddDvd()
        {
            DvdViewModel newDvd = new DvdViewModel();
            DvdViewModel response = new DvdViewModel();
            newDvd.Title = "New DVD Title";
            newDvd.RealeaseYear = 2015;
            newDvd.Director = "New Director";
            newDvd.Rating = "R";
            newDvd.Notes = "Testing the Add function";

            response = repo.Create(newDvd);

            Assert.AreEqual(3, response.DvdId);
        }

        [Test]
        public void DeleteDvd()
        {
            repo.Delete(3);
            List<DvdViewModel> response = new List<DvdViewModel>();
            response = repo.GetAll();
            Assert.AreEqual(3, response.Count());
        }

        [Test]
        public void UpdateDvd()
        {
            DvdViewModel newDvd = new DvdViewModel();
            DvdViewModel response = new DvdViewModel();
            newDvd.Title = "Changed DVD Title";
            newDvd.RealeaseYear = 2011;
            newDvd.Director = "New Director";
            newDvd.Rating = "R";
            newDvd.Notes = "Testing the Add function";

            response = repo.Create(newDvd);

            Assert.AreEqual(2011, response.RealeaseYear);

        }
    }
}