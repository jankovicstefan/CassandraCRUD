using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cassandra;
using Cassandra.Mapping;
using CassandraCRUD.Models;
using System.Collections;

namespace CassandraCRUD.Controllers
{
    public class JobController : Controller
    {
        IMapper mapper = SessionManager.getMapper();
        // GET: Job
        public ActionResult Index()
        {
            
            IEnumerable<Job> results = mapper.Fetch<Job>("SELECT * FROM jobs").AsEnumerable<Job>();
            return View(results);
        }

        // GET: Job/Details/5
        public ActionResult Details(Guid id)
        {
            Job result = mapper.Fetch<Job>("SELECT * FROM jobs WHERE jobID = ?", id).FirstOrDefault();
            return View(result);
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Job newJob = new Job();
                newJob.Id = Guid.NewGuid();
                newJob.JobTitle = collection["JobTitle"];
                newJob.Company = collection["Company"];
                newJob.Category = collection["Category"];
                newJob.Email = collection["Email"];
                newJob.City = collection["City"];
                newJob.Phone = collection["Phone"]; ;
                newJob.Description = collection["Description"];

                mapper.Insert(newJob);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Job/Edit/5
        public ActionResult Edit(Guid id)
        {
            Job result = mapper.Fetch<Job>("SELECT * FROM jobs WHERE jobID = ?", id).FirstOrDefault();
            return View(result);
            
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(Job job)
        {
            try
            {
                // TODO: Add update logic here
                mapper.Update<Job>(job);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Job/Delete/5
        public ActionResult Delete(Guid id)
        {
            Job result = mapper.Fetch<Job>("SELECT * FROM jobs WHERE jobID = ?", id).FirstOrDefault();
            return View(result);
        }

        // POST: Job/Delete/5
        [HttpPost]
        public ActionResult Delete(Job job)
        {
            try
            {
                // TODO: Add delete logic here
                mapper.Delete(job);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
