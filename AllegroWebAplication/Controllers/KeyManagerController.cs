using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllegroWebAplication.Models;
using AllegroWebAplication.KeySenderModels;
using AllegroWebAplication.ViewModels;

namespace AllegroWebAplication.Controllers
{
    public class KeyManagerController : Controller
    {
        ApplicationDbContext db;

        public KeyManagerController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<KeyManagerViewModel> keyManagersToView = new List<KeyManagerViewModel>();
            var keyManagers = db.KeysManagers;

            foreach (var manager in keyManagers)
            {

                keyManagersToView.Add(new KeyManagerViewModel()
                {
                    AuctionId = manager.AuctionID,
                    Id = manager.Id,
                    ManagerName = manager.FactoryName,
                    NumOfKeys = 0
                });
            }
            keyManagersToView.ForEach(m => m.NumOfKeys = db.KeysManagers.Find(m.Id).Keys.Count);

            return View(keyManagersToView);
        }

        public ActionResult AddOrUpdate(int? id)
        {
            if (id == null)
                return View();
            var keyManager = db.KeysManagers.Find(id);
            var keyManagerViewModel = new KeyManagerAddOrUpdateViewModel()
            {
                Id = keyManager.Id,
                AuctionID = keyManager.AuctionID,
                FactoryName = keyManager.FactoryName,
                Keys = keyManager.Keys
            };
            return View(keyManagerViewModel);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(KeyManagerAddOrUpdateViewModel m)
        {
            if (m.Id == null)
            {
                var newManager = new KeyManagerModel()
                {
                    FactoryName = m.FactoryName,
                    AuctionID = m.AuctionID,
                    Keys = m.Keys
                };
                db.KeysManagers.Add(newManager);
                db.SaveChanges();
            }
            else
            {
                var editManager = db.KeysManagers.Find(m.Id);
                editManager.Keys = m.Keys;
                editManager.FactoryName = m.FactoryName;
                editManager.AuctionID = m.AuctionID;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ManageKeys(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var keys = from r in db.KeysManagers where r.Id == id select r.Keys;

            var keysViewModel = new List<KeyManagerKeyViewModel>();
            foreach (var key in keys)
            {
                foreach (var k in key)
                {
                    keysViewModel.Add(new KeyManagerKeyViewModel()
                    {
                        Id = k.Id,
                        Value = k.Value
                    });
                }

            }
            return View(keysViewModel);
        }

        public ActionResult DeleteKey(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var keyToDelete = new Key() { Id = id.GetValueOrDefault() };
            db.Keys.Attach(keyToDelete);
            db.Keys.Remove(keyToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddKeysForManager(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var r = new AddingMultipleKeysViewModel()
            {
                ManagerId = id.GetValueOrDefault()
            };

            return View(r);
        }

        [HttpPost]
        public ActionResult AddKeysForManager(AddingMultipleKeysViewModel model)
        {
            var keys = model.KeyValues.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var keyManager = db.KeysManagers.Where(m => m.Id == model.ManagerId).FirstOrDefault();
            if (keyManager.Keys == null)
                keyManager.Keys = new List<Key>();
            foreach (var key in keys)
            {
                keyManager.Keys.Add(new Key()
                {
                    Value = key
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteManager(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var managerToDelete = new KeyManagerModel() { Id = id.GetValueOrDefault() };
            db.KeysManagers.Attach(managerToDelete);
            db.KeysManagers.Remove(managerToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}