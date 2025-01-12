using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSharpFinal.Adapters;
using CSharpFinal.InventorySystem;

namespace ASP.NET_UI.Pages
{
    public class IndexModel : PageModel
    {
        EquipmentData equipmentData = new EquipmentData();
        
        private bool IsPost = false;
        private InventoryManagementSystem IMS;
        public IndexModel(IInputAdapter IMS)
        {
            this.IMS = (InventoryManagementSystem) IMS;
            this.IMS.ReadAllComponets();
        }

        public void OnGet()
        {
            
        }
        public IActionResult OnPostAddComponent()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            equipmentData.EquipmentID = Convert.ToInt32(Request.Form["ID"]);
            equipmentData.EquipmentName = Request.Form["Name"];
            equipmentData.PurchaseDate = Convert.ToDateTime(Request.Form["DOP"]);
            equipmentData.InstallationDate = Convert.ToDateTime(Request.Form["InstallDate"]);
            equipmentData.EOLDate = Convert.ToDateTime(Request.Form["EOL"]);

            IMS.CreateEquipment(equipmentData);

            return RedirectToPage();
        }
    }
}
