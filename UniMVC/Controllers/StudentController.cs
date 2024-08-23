using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniMVC.Models;
using UniMVC.UnitOfWork;

namespace UniMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var students = _unitOfWork.Student.GetAll().ToList();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = _unitOfWork.Student.GetStudentWithGroup(id);
            return View(student);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> GroupList = _unitOfWork.Group.
                GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name, 
                    Value = u.Id.ToString()
                });
            ViewBag.GroupList = GroupList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _unitOfWork.Student.Add(student);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = _unitOfWork.Student.GetStudentWithGroup(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _unitOfWork.Student.Update(student);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = _unitOfWork.Student.GetStudentWithGroup(id);

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Student.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}