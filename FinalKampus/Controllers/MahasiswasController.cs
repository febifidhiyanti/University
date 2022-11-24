using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalKampus.Models;

namespace FinalKampus.Controllers
{
    public class MahasiswasController : Controller
    {
        private KampusEntities db = new KampusEntities();

        // GET: Mahasiswas
        public ActionResult Index()
        {
            var mahasiswas = db.Mahasiswas.Include(m => m.MataKuliah).Include(m => m.Seminar);
            return View(mahasiswas.ToList());
        }

        // GET: Mahasiswas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Create
        public ActionResult Create()
        {
            ViewBag.IDMataKuliah = new SelectList(db.MataKuliahs, "matakuliah_id", "matakuliah_nama", "matakuliah_harga");
            ViewBag.IDSeminar = new SelectList(db.Seminars, "seminar_id", "seminar_nama", "seminar_harga");
            return View();
        }

        // POST: Mahasiswas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NRP,IDMataKuliah,IDSeminar,mahasiswa_semester,mahasiswa_nama,mahasiswa_jurusan,mahasiswa_alamat")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Mahasiswas.Add(mahasiswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMataKuliah = new SelectList(db.MataKuliahs, "matakuliah_id", "matakuliah_nama", mahasiswa.IDMataKuliah);
            ViewBag.IDSeminar = new SelectList(db.Seminars, "seminar_id", "seminar_nama", mahasiswa.IDSeminar);
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMataKuliah = new SelectList(db.MataKuliahs, "matakuliah_id", "matakuliah_nama", mahasiswa.IDMataKuliah);
            ViewBag.IDSeminar = new SelectList(db.Seminars, "seminar_id", "seminar_nama", mahasiswa.IDSeminar);
            return View(mahasiswa);
        }

        // POST: Mahasiswas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NRP,IDMataKuliah,IDSeminar,mahasiswa_semester,mahasiswa_nama,mahasiswa_jurusan,mahasiswa_alamat")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahasiswa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMataKuliah = new SelectList(db.MataKuliahs, "matakuliah_id", "matakuliah_nama", mahasiswa.IDMataKuliah);
            ViewBag.IDSeminar = new SelectList(db.Seminars, "seminar_id", "seminar_nama", mahasiswa.IDSeminar);
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            db.Mahasiswas.Remove(mahasiswa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
