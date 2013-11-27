using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMvc.Models;

namespace GameMvc.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCharacter(UICharacterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            GameLogic.Player p = new GameLogic.Player();
            p.SetName(model.Name);
            Session["Player"] = p;
            return View("Character", p);
        }

        public ActionResult Character()
        {
            GameLogic.Player p = (GameLogic.Player)Session["Player"];
            if (p == null)
            {
                ModelState.AddModelError(string.Empty, "You must create a character first.");
                return View("Index");
            }            
            return View("Character", p);            
        }

        public ActionResult Arena()
        {
            GameLogic.Player p = (GameLogic.Player)Session["Player"];
            if (p == null)
            {
                ModelState.AddModelError(string.Empty, "You must create a character first.");
                return View("Index");
            }

            GameLogic.Arena a = new GameLogic.Arena();
            a.BuildArenaFloor(5);
            a.AddCharacterToArena(p);
            Session["Arena"] = a;

            return View("Arena", a);
        }

        public ActionResult Shop()
        {
            GameLogic.Player p = (GameLogic.Player)Session["Player"];
            if (p == null)
            {
                ModelState.AddModelError(string.Empty, "You must create a character first.");
                return View("Index");
            }    
            GameLogic.Shop s = new GameLogic.Shop();
            s.AddPlayerToShop(p);

            return View("Shop", s);
        }

        [HttpPost]
        public ActionResult PurchaseEquipment(string name)
        {
            GameLogic.Player p = (GameLogic.Player)Session["Player"];
            GameLogic.Shop s = new GameLogic.Shop();
            var e = s.Equipment.First(i => i.Name == name);
            if (e == null)
            {
                // TODO - Exception
            }
            p.PurchaseEquipment(e);
            s.AddPlayerToShop(p);
            Session["Player"] = p;

            return View("Shop", s);
        }

        [HttpPost]
        public ActionResult SellEquipment(string name)
        {
            GameLogic.Player p = (GameLogic.Player)Session["Player"];
            GameLogic.Shop s = new GameLogic.Shop();
            var e = p.CharacterEquipment.First(i => i.Name == name);
            if (e == null)
            {
                // TODO - Exception
            }
            p.SellEquipment(e);
            s.AddPlayerToShop(p);
            Session["Player"] = p;

            return View("Shop", s);
        }
    }
}
