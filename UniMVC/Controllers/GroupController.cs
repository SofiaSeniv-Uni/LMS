using Microsoft.AspNetCore.Mvc;
using UniMVC.Models;
using UniMVC.UnitOfWork;

namespace UniMVC.Controllers
{
    public class GroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Group> groups = _unitOfWork.Group.GetAll().ToList();
            return View(groups);
        }

        public IActionResult Details(int id)
        {
            var group = _unitOfWork.Group.GetGroupWithStudents(id);

            return View(group);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Group group)
        {
            _unitOfWork.Group.Add(group);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Group group = _unitOfWork.Group.GetById(id);
            return View(group);
        }

        [HttpPost]
        public IActionResult Edit(Group group)
        {
            _unitOfWork.Group.Update(group);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Group group = _unitOfWork.Group.GetById(id);
            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Group.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
