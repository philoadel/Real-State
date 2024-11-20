using BL.Interfaces;
using DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Real_State_System.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get All
        public IActionResult Index()
        {
            var properties = _unitOfWork.PropertyRepository.GetAll();
            return View(properties);
        } 
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Property property)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PropertyRepository.Add(property);
                int result = _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(property);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id, string Viewname = "Details")
        {
            if (id == null)
                return BadRequest();
            var property = _unitOfWork.PropertyRepository.GetById(id.Value);
            if (property == null)
                return NotFound();
            return View(Viewname, property);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]

        public IActionResult Edit(Property property, [FromRoute] int id)
        {
            if (id != property.PropertyId)
                return BadRequest();
            if (ModelState.IsValid)
            {
                _unitOfWork.PropertyRepository.Update(property);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(property);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Property property, [FromRoute] int id)
        {
            if (id != property.PropertyId)
                return BadRequest();
            if (ModelState.IsValid)
            {

                _unitOfWork.PropertyRepository.Delete(property);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(property);
        }     
        #endregion


    }
}
