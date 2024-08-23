using Microsoft.AspNetCore.Mvc;
using UniMVC.Models;
using UniMVC.UnitOfWork;

namespace UniMVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Teacher> teachers = _unitOfWork.Teacher.GetAll().ToList();
            return View(teachers);  
        }

        public IActionResult Details(int id)
        {
            var teacher = _unitOfWork.Teacher.GetById(id);
            return View(teacher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            _unitOfWork.Teacher.Add(teacher);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var teacher = _unitOfWork.Teacher.GetById(id);
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            _unitOfWork.Teacher.Update(teacher);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var teacher = _unitOfWork.Teacher.GetById(id);
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]  
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Teacher.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}