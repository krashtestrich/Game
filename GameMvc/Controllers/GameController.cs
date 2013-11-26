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
            GameLogic.Player p = new GameLogic.Player();
            Session["Player"] = p;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCharacter(UICharacterModel model)
        {
            GameLogic.Player p = Session["Player"] == null ? new GameLogic.Player() : (GameLogic.Player)Session["Player"];   
            if (ModelState.IsValid)
            {             
                p.SetName(model.Name);
                Session["Player"] = p;
            }

            // If we got this far, something failed, redisplay form
            return View("Character", p);
        }

        public ActionResult GoToArena()
        {
            GameLogic.Player p = (GameLogic.Player)Session["Player"];
            GameLogic.Arena a = new GameLogic.Arena();
            a.BuildArenaFloor(5);
            a.AddCharacterToArena(p);
            Session["Arena"] = a;

            return View("Arena", a);
        }

        public ActionResult GoToShop()
        {
            GameLogic.Player p = (GameLogic.Player)Session["Player"];
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
    }
}
