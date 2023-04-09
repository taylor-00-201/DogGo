using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogGo.Models;
using DogGo.Controllers;
using DogGo.Interfaces;

namespace DogGo.Controllers
{
    public class OwnerController : Controller
    {

        private readonly IOwnerRepository _OwnerRepo;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _OwnerRepo = ownerRepository;
        }


        // GET: OwnerController
        public ActionResult Index()
            // uses dependency injection to get a transient version of the ownersrepository, executes the getallowners function, and returns a view of the owners in mvc
        {
            List<Owner> owners = _OwnerRepo.GetAllOwners();
            return View(owners);
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(int id)
        // uses dependency injection to get a transient version of the ownersrepository, executes the getownerbyid function, and returns a view of the owner retrieved by their id in mvc
        {
            Owner owner = _OwnerRepo.GetOwnerById(id);

            if (owner == null) 
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        // This is a Nashville Software School provided action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                 owner.NeighborhoodId = 1; // this default value was added in order for the form to complete
                _OwnerRepo.AddOwner(owner);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        // the contents of this method were provided by Nashville Software School
        public ActionResult Delete(int id)
        {
            Owner owner = _OwnerRepo.GetOwnerById(id);

            return View(owner);
        }

        // POST: OwnerController/Delete/5
        // POST: Owners/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Owner owner)
            // this internal method was provided by Nashville Software School
        {
            try
            {
                _OwnerRepo.DeleteOwner(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }
    }
}
