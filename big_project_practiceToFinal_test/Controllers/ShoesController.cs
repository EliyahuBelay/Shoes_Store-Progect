using big_project_practiceToFinal_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace big_project_practiceToFinal_test.Controllers
{
    public class ShoesController : Controller
    {
        Shoes[] listOfShoes = new Shoes[]
        {
            new Shoes(0,"Nike","Shoks",48,1000),
            new Shoes(1,"Adidar","Dor",38,50),
            new Shoes(3,"Nike","Air",46,7000),
            new Shoes(4,"kappa","GT",41,200),
        };
        // GET: Shoes
        public ActionResult DispalyBrandName()
        {
            ViewBag.Name = listOfShoes[0].NameModel;
            return View();
        }
        
        public ActionResult DispalyShoese(int id)
        {
            Shoes shoesObj = listOfShoes.First(item => item.Id == id);
            return View(shoesObj);
        }
        public ActionResult DispalyAllShoese()
        {
            return View(listOfShoes);
        }
    }
}