using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSharpFinal.Adapters;
using CSharpFinal.InventorySystem;

namespace ASP.NET_UI.Pages.Components
{
    public class ComponentModel : PageModel
    {
        ComponentData componentData = new ComponentData();

        private bool IsPost = false;
        private InventoryManagementSystem IMS;
        public ComponentModel(IInputAdapter IMS)
        {
            this.IMS = (InventoryManagementSystem)IMS;
            this.IMS.ReadAllComponets();
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                componentData.ComponentID = Convert.ToInt32(Request.Form["ID"]);
                componentData.ComponentName = Request.Form["Name"];
                componentData.PurchaseDate = Convert.ToDateTime(Request.Form["DOP"]);
                componentData.InstallationDate = Convert.ToDateTime(Request.Form["InstallDate"]);
                componentData.EndOLDate = Convert.ToDateTime(Request.Form["EOL"]);

                IMS.CreateComponent(componentData);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
