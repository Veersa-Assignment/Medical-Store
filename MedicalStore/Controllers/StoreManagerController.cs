using MedicalStore.Data;
using MedicalStore.Migrations;
using MedicalStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace MedicalStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StoreManagerController(ApplicationDbContext db) { 
            _db=db;
        
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(StoreManager obj)
        {
            var categoryFromDb = _db.StoreManagers.Find(obj.Email);
            if (categoryFromDb != null)
            {
                if (categoryFromDb.Password == obj.Password)
                {
                    
                    return RedirectToAction("Logged_in_as_StoreManager");
                }

            }
            TempData["failed"] = "Try Again";
            return View();
        }
        public IActionResult Logged_in_as_StoreManager()
        {
            IEnumerable<Inventory> objCategoryList = _db.Inventories;

            return View(objCategoryList);
        }
        public IActionResult NewStoreKeeper()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewStoreKeeper(StoreKeeper obj)
        {

            if (ModelState.IsValid)
            {
                _db.StoreKeepers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "StoreKeeper Added Successfully";
                return RedirectToAction("Logged_in_as_StoreManager");
            }
            else
            {
                return View();
            }
        }
        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddItem(Inventory obj)
        {
            if (ModelState.IsValid)
            {
                obj.Approved = 1;
                obj.Final = obj.StockIn - obj.Expired;
            var category=_db.Inventories.Where(d=> d.MedicineName==obj.MedicineName);
            if (category.Any())
                

            {
                var a=category.ToList();
                    a[0].StockIn += obj.StockIn;
                    a[0].Expired += obj.Expired;
                a[0].Final = a[0].StockIn - (a[0].Expired + a[0].StockOut);
                    
                _db.Inventories.Update(a[0]);
                _db.SaveChanges(true);
                return RedirectToAction("Logged_in_as_StoreManager");

            }


            obj.StockOut = 0;
            
            
                _db.Inventories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Inventory Added Successfully";
                return RedirectToAction("Logged_in_as_StoreManager");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Approve()
        {
            IEnumerable<Pending> objCategoryList = _db.Pendings;

            return View(objCategoryList);
            
        }
        public IActionResult Approved(int? id)
        {
            var obj=_db.Pendings.Find(id);
            var category = _db.Inventories.Where(d => d.MedicineName == obj.MedicineName);
            List<Inventory> a = new List<Inventory>();
            if (category.Any())


            {
                a = category.ToList();
                a[0].StockIn += obj.StockIn;
                a[0].Expired += obj.Expired;
                a[0].Final = a[0].StockIn - (a[0].Expired + a[0].StockOut);
                _db.Inventories.Update(a[0]);
            }
            else
            {
                var b=new Inventory();
               
                b.StockIn = obj.StockIn;
                b.Expired = obj.Expired;
                b.StockOut = 0;
                b.Approved = 1;
                b.MedicineName = obj.MedicineName;
                b.Final = b.StockIn - b.Expired;
                _db.Inventories.Add(b);
            }
            var query = _db.Pendings.Remove(obj);


            _db.SaveChanges(true);
                return RedirectToAction("Logged_in_as_StoreManager");

            
            


        }
        public IActionResult LogOut()
        {
            

            return View();

        }


    }
}
