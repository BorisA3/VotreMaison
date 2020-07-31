using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaisonVotre.Data;
using MaisonVotre.Models;
using MaisonVotre.Models.Carrito;

namespace MaisonVotre.Controllers
{
    public class ProductoesController : Controller
    {
        private MaisonVotreContext db = new MaisonVotreContext();

        

        // GET: Productoes
        public ActionResult Index()
        {
            var productoes = db.Productoes.Include(p => p.Categorias).Include(p => p.Empresas);
            return View(productoes.ToList());
        }

        public ActionResult Pago()
        {
            
            return View();
        }

        public ActionResult Carrito()
        {
            if (Session["cart"] != null)
            {
                return View(Session["cart"]);
            }
            else
            {
                List<Carrito> cart = new List<Carrito>();
                return View(cart);
            }
        }

        public ActionResult AddtoCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<Carrito> cart = new List<Carrito>();
                cart.Add(new Carrito { Producto = db.Productoes.Find(id), Cantidad = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Carrito> cart = (List<Carrito>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Cantidad++;
                }
                else
                {
                    cart.Add(new Carrito { Producto = db.Productoes.Find(id), Cantidad = 1 });
                }
                Session["cart"] = cart;
            }
            return View("Carrito", Session["cart"]);
        }

        public ActionResult RemovefromCart(int id)
        {
            List<Carrito> cart = (List<Carrito>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Carrito");
        }

        public ActionResult DownQuantity(int id)
        {
            List<Carrito> cart = (List<Carrito>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Producto.ProductoId == id && item.Cantidad > 1)
                {
                    item.Cantidad--;
                }
            }

            Session["cart"] = cart;
            return RedirectToAction("Carrito");
        }

        private int isExist(int id)
        {
            List<Carrito> cart = (List<Carrito>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Producto.ProductoId.Equals(id))
                    return i;
            return -1;
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre");
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "EmpresaNombre");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoId,ProductoNombre,ProductPrecio,Imagen,ProductUltimaVenta,ProductExistencia,Productodescripcion,CategoriaId,EmpresaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre", producto.CategoriaId);
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "EmpresaNombre", producto.EmpresaId);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre", producto.CategoriaId);
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "EmpresaNombre", producto.EmpresaId);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoId,ProductoNombre,ProductPrecio,Imagen,ProductUltimaVenta,ProductExistencia,Productodescripcion,CategoriaId,EmpresaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre", producto.CategoriaId);
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "EmpresaNombre", producto.EmpresaId);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
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
