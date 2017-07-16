using DVDRepoWebApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVDRepoWebApi.Models.Interfaces
{
    public interface IDvdRepository
    {
        List<DvdViewModel> GetAll();
        DvdViewModel GetById(int id);
        List<DvdViewModel> GetByTitle(string title);
        List<DvdViewModel> GetByYear(int year);
        List<DvdViewModel> GetByDirector(string director);
        List<DvdViewModel> GetByRating(string rating);
        DvdViewModel Create(DvdViewModel dvd);
        void Update(int id, DvdViewModel dvd);
        void Delete(int id);
    }
}
