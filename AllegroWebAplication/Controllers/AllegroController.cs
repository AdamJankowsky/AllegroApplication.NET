using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllegroWebAplication.Providers.Interfaces;
using AllegroWebAplication.AllegroModels;

namespace AllegroWebAplication.Controllers
{
    public class AllegroController : Controller
    {
        IAllegroApiWrapper wrapper;

        public AllegroController(IAllegroApiWrapper _wrapper)
        {
            wrapper = _wrapper;
        }
        
        // GET: Allegro
        public ActionResult Index()
        {
            

            return View();
        }
        public ActionResult ListBoughtItems()
        {
            var boughtItems = wrapper.GetMyWonItems();

            return View(boughtItems);
        }
        public ActionResult ListSellingItems()
        {
            var sellingItems = wrapper.GetMySellItems();
            return View(sellingItems);
        }
        public ActionResult ListListSoldItems()
        {
            var soldItems = wrapper.GetMySoldItems();
            return View(soldItems);
        }
    }
}