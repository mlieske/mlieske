using Exercises.Models.Data;
using Exercises.Models.Repositories;
using Exercises.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll().OrderBy(m => m.MajorName);
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            else
            {
                return View("AddMajor");
            }
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            List<State> states = StateRepository.GetAll().OrderBy(s => s.StateAbbreviation).ToList();
            return View(states);
        }

        [HttpGet]
        public ActionResult AddState()
        {
            State model = new State();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (ModelState.IsValid)
            {
                StateRepository.Add(state);
                return RedirectToAction("States");
            }
            else
            {
                return View("AddState");
            }
        }

        [HttpGet]
        public ActionResult EditState(string id)
        {
            //get state info and send to form - prepopulated
            StateEditVM model = new StateEditVM();
            model.NewState = StateRepository.Get(id);
            model.OldStateAbbrev = model.NewState.StateAbbreviation;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditState(StateEditVM stateVM)
        {
            StateRepository.Edit(stateVM);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            State model = new State();
            model = StateRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll().OrderBy(c => c.CourseName).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
                Course model = new Course();
                return View(model);
        }

        [HttpPost]
        public ActionResult AddCourse(string courseName)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(courseName))
            {
                
                    CourseRepository.Add(courseName);
                    return RedirectToAction("Courses");
                
            }
            else
            {
                return View("AddCourse");
            }
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            
            Course model = CourseRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            CourseRepository.Edit(course);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            Course model = CourseRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }

    }
}