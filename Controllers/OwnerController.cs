﻿using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}