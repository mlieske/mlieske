using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid) { 
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View("Add", studentVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentVM studentVM = new StudentVM();
            studentVM.Student = StudentRepository.Get(id);
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.SetStateItems(StateRepository.GetAll());
            return View(studentVM);
        }
        
        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {

            if (studentVM.SelectedCourseIds.Count() != 0)
            {
                studentVM.Student.Courses = new List<Course>();
                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));
            }
            else
            {
                studentVM.Student.Courses = StudentRepository.Get(studentVM.Student.StudentId).Courses;
            }


            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Edit(studentVM.Student);

            if (studentVM.Student.Address.AddressId == 0)
            {
                var students = StudentRepository.GetAll();
                var addresses = students.Where(m => m.Address != null).ToList();
                var addressId = addresses.Max(m => m.Address.AddressId);
                studentVM.Student.Address.AddressId = addressId + 1;
            }

            studentVM.Student.Address.State.StateName = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation).StateName;
            StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
            return RedirectToAction("List");
        }

        //[HttpPost]
        //public ActionResult SaveAddress(Student student)
        //{
        //    student.Address.State.StateName = StateRepository.Get(student.Address.State.StateAbbreviation).StateName;
        //    StudentRepository.SaveAddress(student.StudentId, student.Address);
        //    return RedirectToAction("Edit",new { id = student.StudentId });
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student model = StudentRepository.Get(id);
            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}