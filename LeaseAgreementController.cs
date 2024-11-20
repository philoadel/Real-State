using BL.Interfaces;
using DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Real_State_System.Controllers
{
    public class LeaseAgreementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaseAgreementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get All
        public IActionResult Index()
        {
            var properties = _unitOfWork.LeaseAgreementRepository.GetAll();
            return View(properties);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LeaseAgreement LeaseAgreement)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LeaseAgreementRepository.Add(LeaseAgreement);
                int result = _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(LeaseAgreement);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id, string Viewname = "Details")
        {
            if (id == null)
                return BadRequest();
            var LeaseAgreement = _unitOfWork.LeaseAgreementRepository.GetById(id.Value);
            if (LeaseAgreement == null)
                return NotFound();
            return View(Viewname, LeaseAgreement);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]

        public IActionResult Edit(LeaseAgreement LeaseAgreement, [FromRoute] int id)
        {
            if (id != LeaseAgreement.LeaseAgreementId)
                return BadRequest();
            if (ModelState.IsValid)
            {
                _unitOfWork.LeaseAgreementRepository.Update(LeaseAgreement);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(LeaseAgreement);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(LeaseAgreement LeaseAgreement, [FromRoute] int id)
        {
            if (id != LeaseAgreement.LeaseAgreementId)
                return BadRequest();
            if (ModelState.IsValid)
            {

                _unitOfWork.LeaseAgreementRepository.Delete(LeaseAgreement);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(LeaseAgreement);
        }
        #endregion
    }
}
