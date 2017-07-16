using DVDRepoWebApi.Data.Repositories;
using DVDRepoWebApi.Models.Interfaces;
using DVDRepoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DVDRepoWebApi.Models.Models;
using DVDRepoWebApi.Data;

namespace DVDRepoWebApi.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DvdController : ApiController
    {
        private IDvdRepository _DvdRepository;

        //public DvdController(IDvdRepository repo)
        //{
        //    _DvdRepository = repo;
        //}

        public DvdController()
        {
            //_DvdRepository = new DVDRepositoryADO();
            _DvdRepository = DvdRepositoryFactory.Create();
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(_DvdRepository.GetAll());
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var found = _DvdRepository.GetByTitle(title);

            if (found == null)
                return NotFound();
            else return Ok(found);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            var found = _DvdRepository.GetByRating(rating);

            if (found == null)
                return NotFound();
            else return Ok(found);
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(int year)
        {
            var found = _DvdRepository.GetByYear(year);

            if (found == null)
                return NotFound();
            else return Ok(found);
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            var found = _DvdRepository.GetByDirector(director);

            if (found == null)
                return NotFound();
            else return Ok(found);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            var found = _DvdRepository.GetById(id);

            if (found == null)
                return NotFound();
            else return Ok(found);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _DvdRepository.Delete(id);
            //return Ok(_DvdRepository.GetAll());
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Create(DvdViewModel dvd)
        {
            var newDvd = _DvdRepository.Create(dvd);
            return Created("",newDvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, DvdViewModel dvd)
        {
            _DvdRepository.Update(id,dvd);
        }
    }
}