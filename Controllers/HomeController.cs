using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) { 
                //retourn to the Index view (see routing in Program.cs)
                vueData("Home");
                return View();
            }
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        OpinionList opinions = new OpinionList();
                        List<Opinion> ListeAvis = opinions.GetAvis("XlmFile/DataAvis.xml");

                        vueData("Avis");
                        return View(id,ListeAvis);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        vueData("Form");
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        vueData("Home");
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire(Form form)
        {
            //TODO : test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            if (!ModelState.IsValid)
            {
                vueData("Form");
                return View("Form");
            }
            else
            {
                vueData("Validation");
                return View(form);
            }

        }


        private void vueData(string data)
        {
            switch (data)
            {
                case "Home":
                    ViewData["Title"] = "HN - TP LOCAL";
                    ViewData["Header"] = "Bienvenue dans le TP HN";
                    ViewData["Menu1"] = "Remplir le formulaire";
                    ViewData["Menu2"] = "Liste avis";
                    ViewData["Link1"] = "/Home/Index/Form";
                    ViewData["Link2"] = "/Home/Index/OpinionList";
                    break;
                case "Form":
                    ViewData["Title"] = "Formulaire";
                    ViewData["Header"] = "Formulaire TP HN avis";
                    ViewData["Menu1"] = "Accueil";
                    ViewData["Menu2"] = "Liste avis";
                    ViewData["Link1"] = "/Home/Index";
                    ViewData["Link2"] = "/Home/Index/OpinionList";
                    break;
                case "Validation":
                    ViewData["Title"] = "Page de validation";
                    ViewData["Header"] = "Page de validation";
                    ViewData["Menu1"] = "Accueil";
                    ViewData["Menu2"] = "Liste avis";
                    ViewData["Link1"] = "/Home/Index";
                    ViewData["Link2"] = "/Home/Index/OpinionList";
                    break;
                case "Avis":
                    ViewData["Title"] = "Liste des avis";
                    ViewData["Header"] = "Liste des avis";
                    ViewData["Menu1"] = "Accueil";
                    ViewData["Menu2"] = "Formulaire";
                    ViewData["Link1"] = "/Home/Index";
                    ViewData["Link2"] = "/Home/Index/Form";
                    break;
                default:
                    break;
            }
        }
    }
}