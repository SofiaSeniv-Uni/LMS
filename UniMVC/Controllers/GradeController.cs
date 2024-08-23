using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniMVC.Data;
using UniMVC.Models;
using UniMVC.UnitOfWork;

namespace UniMVC.Controllers
{
    public class GradeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GradeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var studentGrades = _unitOfWork.StudentGrades.GetStudentAndDiscipline();
            return View(studentGrades);
        }

        public ActionResult Create()
        {
            IEnumerable<SelectListItem> StudentList = _unitOfWork.Student.
               GetAll().Select(u => new SelectListItem
               {
                   Text = $"{u.Name} {u.Surname}",
                   Value = u.Id.ToString()
               });
            IEnumerable<SelectListItem> DisciplineList = _unitOfWork.Discipline.
               GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               });


            ViewBag.Students = StudentList;
            ViewBag.Disciplines = DisciplineList;
            return View();
        }


        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentGrades studentGrade)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StudentGrades.Add(studentGrade);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Students = _unitOfWork.Student.GetAll().ToList();
            ViewBag.Disciplines = _unitOfWork.Discipline.GetAll().ToList();
            return View(studentGrade);
        }
    }
}