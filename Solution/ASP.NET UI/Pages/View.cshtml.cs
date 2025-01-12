using CSharpFinal.Adapters;
using CSharpFinal.InventorySystem;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_UI.Pages
{
    public class ViewModel : PageModel
    {
        private InventoryManagementSystem IMS;
        public ViewModel(IInputAdapter IMS)
        {
            this.IMS = (InventoryManagementSystem)IMS;
            this.IMS.ReadAllComponets();
            this.IMS.ReadAllEquipments();
        }
        public void OnGet()
        {
            IMS.ReadAllEquipments();
        }

        public void OnGett()
        {
            IMS.ReadAllComponets();
        }


    }
}
