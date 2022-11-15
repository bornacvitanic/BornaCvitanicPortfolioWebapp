using BornaCvitanicPortfolioWebapp.Models.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace BornaCvitanicPortfolioWebapp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            this.FillDropdownValues();
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            CultureInfo[] getcultureinfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            
            List<string> Culturelist = new List<string>();
            
            foreach (CultureInfo getculture in getcultureinfo)
            {
                RegionInfo getregininfo = new RegionInfo(getculture.LCID);
                if (!(Culturelist.Contains(getregininfo.EnglishName)))
                {
                    Culturelist.Add(getregininfo.EnglishName);
                }
            }
            Culturelist.Sort();

            selectItems.Add(new SelectListItem("Please select", ""));
            int index = 1;
            foreach (var item in Culturelist)
            {
                selectItems.Add(new SelectListItem(item, index.ToString()));
                index++;
            }

            ViewBag.CountryItems = selectItems;
        }
    }
}
