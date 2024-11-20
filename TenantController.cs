using BL.Interfaces;
using DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Real_State_System.Controllers
{
    public class TenantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TenantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get All
        public IActionResult Index()
        {
            var properties = _unitOfWork.TenantRepository.GetAll();
            return View(properties);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tenant Tenant)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TenantRepository.Add(Tenant);
                int result = _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(Tenant);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id, string Viewname = "Details")
        {
            if (id == null)
                return BadRequest();
            var Tenant = _unitOfWork.TenantRepository.GetById(id.Value);
            if (Tenant == null)
                return NotFound();
            return View(Viewname, Tenant);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]

        public IActionResult Edit(Tenant Tenant, [FromRoute] int id)
        {
            if (id != Tenant.TenantId)
                return BadRequest();
            if (ModelState.IsValid)
            {
                _unitOfWork.TenantRepository.Update(Tenant);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(Tenant);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Tenant Tenant, [FromRoute] int id)
        {
            if (id != Tenant.TenantId)
                return BadRequest();
            if (ModelState.IsValid)
            {

                _unitOfWork.TenantRepository.Delete(Tenant);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(Tenant);
        }
        #endregion
    }
}
