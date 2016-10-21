using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookNet.Models;

namespace BookNet.Controllers
{
    public class BooksController : Controller
    {
        private BookStoreModel db = new BookStoreModel();

        // GET: Books
        public ActionResult Index(string authorname, string titleSearch, string genre)
        {
            ViewBag.IsAdmin = AuthorizationAttribute.IsAdminLogedIn();            

            var BookList = from s in db.Books.Include(b => b.Author)
                           select s;

            if (!String.IsNullOrEmpty(authorname))
            {
                BookList = BookList.Where(s => s.Author.LastName.Contains(authorname));
            }

            if (!String.IsNullOrEmpty(titleSearch))
            {
                BookList = BookList.Where(s => s.Title.Contains(titleSearch));
            }

            if (!String.IsNullOrEmpty(genre))
            {
                BookList = BookList.Where(s => s.Genre.ToString().Contains(genre));
            }

            return View(BookList.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.IsAdmin = (HttpContext.Session["userAuth"] != null && HttpContext.Session["userAuth"].ToString() == Roles.Admin.ToString());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public PartialViewResult Aside()
        {
            var genreList = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            return PartialView("~/Views/Partials/Categories.cshtml", genreList);
        }

        // GET: Books/Create
        [Authorization(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "FirstName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorization(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Genre,Price,Image,AuthorID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "FirstName", book.AuthorID);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorization(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "FirstName", book.AuthorID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorization(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Genre,Price,Image,AuthorID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "FirstName", book.AuthorID);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorization(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorization(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
