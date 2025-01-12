using Spectre.Console;
using System;
using System.Collections.Generic;
using CSharpFinal.Adapters;
using CSharpFinal.InventorySystem;
using CSharpFinal.DataBaseLibrary;

namespace EquipmentApp
{
    class ConsoleAdapterUI : IOutputAdatper
    {
        public InventoryManagementSystem IMS;

        public void DisplayFirstPage()
        {
            while (true)
            {
                var mainSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose what you want to do:")
                        .AddChoices("Enter Equipment", "Enter Components", "View Equipment", "View Components", "Update Equipment", "Update Components", "Delete Equipment", "Delete Components", "Exit"));

                if (mainSelection == "Enter Equipment")
                {
                    DisplayCreateEquipmentPage(new EquipmentData());
                }
                else if (mainSelection == "Enter Components")
                {
                    DisplayCreateComponentPage(new ComponentData());
                }
                else if (mainSelection == "View Equipment")
                {
                    Console.WriteLine("Enter the ID you want to view: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DisplayViewEquipmentPage(id);
                }
                else if (mainSelection == "View Components")
                {
                    Console.WriteLine("Enter the ID you want to view: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DisplayViewComponentPage(id);
                }
                else if (mainSelection == "Update Equipment")
                {
                    Console.WriteLine("Enter the ID you want to update: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DisplayUpdateEquipmentPage(id, new EquipmentData());
                }
                else if (mainSelection == "Update Components")
                {
                    Console.WriteLine("Enter the ID you want to view: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DisplayUpdateComponentPage(id, new ComponentData());
                }
                else if (mainSelection == "Delete Equipment")
                {
                    Console.WriteLine("Enter the ID you want to delete: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DisplayDeleteEquipmentPage(id);
                }
                else if (mainSelection == "Delete Components")
                {
                    Console.WriteLine("Enter the ID you want to view: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DisplayDeleteComponentPage(id);
                }
                else if (mainSelection == "Exit")
                {
                    break;
                }
            }

            AnsiConsole.MarkupLine("\n[italic]Press any key to exit...[/]");
            Console.ReadKey(true);
        }
        public void DisplayCreateComponentPage(ComponentData component)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(new FigletText("Components").Centered().Color(Color.Blue));

                var name = AnsiConsole.Ask<string>("Enter the [blue]Name[/]:");
                var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/]:");
                var dop = AnsiConsole.Ask<string>("Enter the [blue]Date of Purchase (DoP)[/]:");
                var installationDate = AnsiConsole.Ask<string>("Enter the [blue]Date Installed[/]:");
                var decomissionedDate = AnsiConsole.Ask<string>("Enter the [blue]Date Decomissioned[/]:");
                var updateDate = AnsiConsole.Console.Ask<string>("Enter the [blue]Updated Date[/]:");
                var createdDate = AnsiConsole.Console.Ask<string>("Enter the [blue]Created Date[/]:");


                var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

                var componentt = new ComponentData();
                componentt.ComponentName = name;
                componentt.ComponentID = Convert.ToInt32(id);
                componentt.PurchaseDate = Convert.ToDateTime(dop);
                componentt.InstallationDate = Convert.ToDateTime(installationDate);
                componentt.EndOLDate = Convert.ToDateTime(endOfLife);
                componentt.DecommissionedDate = Convert.ToDateTime(decomissionedDate);


                IMS.CreateComponent(componentt);

                var continueInput = AnsiConsole.Confirm("Do you want to enter another component?");
                if (!continueInput)
                {
                    break;
                }
            }
        }

        public void DisplayCreateEquipmentPage(EquipmentData equipment)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(new FigletText("Equipment").Centered().Color(Color.Green));

                var name = AnsiConsole.Ask<string>("Enter the [green]Name[/]:");
                var id = AnsiConsole.Ask<string>("Enter the [green]ID[/]:");
                var dop = AnsiConsole.Ask<string>("Enter the [green]Date of Purchase (DoP)[/]:");
                var installationDate = AnsiConsole.Ask<string>("Enter the [green]Date Installed[/]:");
                var decomissionedDate = AnsiConsole.Ask<string>("Enter the [green]Date Decomissioned[/]:");
                var updateDate = AnsiConsole.Console.Ask<string>("Enter the [green]Updated Date[/]:");
                var createdDate = AnsiConsole.Console.Ask<string>("Enter the [green]Created Date[/]:");


                var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

                var equipmentt = new EquipmentData();
                equipmentt.EquipmentName = name;
                equipmentt.EquipmentID = Convert.ToInt32(id);
                equipmentt.PurchaseDate = Convert.ToDateTime(dop);
                equipmentt.InstallationDate = Convert.ToDateTime(installationDate);
                equipmentt.EOLDate = Convert.ToDateTime(endOfLife);
                equipmentt.DecommissionedDate = Convert.ToDateTime(decomissionedDate);


                IMS.CreateEquipment(equipmentt);

                var continueInput = AnsiConsole.Confirm("Do you want to enter another piece of equipment?");
                if (!continueInput)
                {
                    break;
                }
            }
        }

        public void DisplayDeleteComponentPage(int compID)
        {
            var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/] of the component to delete:");
            IMS.DeleteComponent(Convert.ToInt32(id));
        }

        public void DisplayDeleteEquipmentPage(int equipID)
        {
            var id = AnsiConsole.Ask<string>("Enter the [green]ID[/] of the equipment to delete:");
            IMS.DeleteEquipment(Convert.ToInt32(id));
        }

        public void DisplayUpdateComponentPage(int compID, ComponentData component)
        {
            var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/] of the component to update:");

            var name = AnsiConsole.Ask<string>("Enter the [green]Name[/]:");
            var dop = AnsiConsole.Ask<string>("Enter the [green]Date of Purchase (DoP)[/]:");
            var installationDate = AnsiConsole.Ask<string>("Enter the [green]Date Installed[/]:");
            var decomissionedDate = AnsiConsole.Ask<string>("Enter the [green]Date Decomissioned[/]:");
            var updateDate = AnsiConsole.Console.Ask<string>("Enter the [green]Updated Date[/]:");
            var createdDate = AnsiConsole.Console.Ask<string>("Enter the [green]Created Date[/]:");


            var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

            var componentt = new ComponentData();
            componentt.ComponentID = Convert.ToInt32(id);
            componentt.PurchaseDate = Convert.ToDateTime(dop);
            componentt.ComponentName = name;
            componentt.InstallationDate = Convert.ToDateTime(installationDate);
            componentt.EndOLDate = Convert.ToDateTime(endOfLife);
            componentt.DecommissionedDate = Convert.ToDateTime(decomissionedDate);

            IMS.UpdateComponent(Convert.ToInt32(id), componentt);
        }

        public void DisplayUpdateEquipmentPage(int equipID, EquipmentData equipment)
        {
            var id = AnsiConsole.Ask<string>("Enter the [green]ID[/] of the equipment to update:");

            var name = AnsiConsole.Ask<string>("Enter the [green]Name[/]:");
            var dop = AnsiConsole.Ask<string>("Enter the [green]Date of Purchase (DoP)[/]:");
            var installationDate = AnsiConsole.Ask<string>("Enter the [green]Date Installed[/]:");
            var decomissionedDate = AnsiConsole.Ask<string>("Enter the [green]Date Decomissioned[/]:");
            var updateDate = AnsiConsole.Console.Ask<string>("Enter the [green]Updated Date[/]:");
            var createdDate = AnsiConsole.Console.Ask<string>("Enter the [green]Created Date[/]:");


            var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

            var equipmentt = new EquipmentData();
            equipmentt.EquipmentName = name;
            equipmentt.PurchaseDate = Convert.ToDateTime(dop);
            equipmentt.InstallationDate = Convert.ToDateTime(installationDate);
            equipmentt.EOLDate = Convert.ToDateTime(endOfLife);
            equipmentt.DecommissionedDate = Convert.ToDateTime(decomissionedDate);

            IMS.UpdateEquipment(Convert.ToInt32(id), equipmentt);
        }

        public ComponentData DisplayViewComponentPage(int compID)
        {
            var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/] of the component to view:");
            IMS.ReadComponent(Convert.ToInt32(id));
            return new ComponentData();
        }

        public EquipmentData DisplayViewEquipmentPage(int EquipID)
        {
            var id = AnsiConsole.Ask<string>("Enter the [green]ID[/] of the equipment to view:");
            IMS.ReadEquipment(Convert.ToInt32(id));
            return new EquipmentData();
        }

        public List<ComponentData> ReadAllComponetPage()
        {
            throw new NotImplementedException();
        }

        public List<EquipmentData> ReadAllEquipmentPage()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            var outAdapter = new ConsoleAdapterUI();
            var dbAdapter = new SQLiteAdapter();
            var IMS = new InventoryManagementSystem(dbAdapter, outAdapter);

            outAdapter.IMS = IMS;
            outAdapter.DisplayFirstPage();
            //while (true)
            //{
            //    var mainSelection = AnsiConsole.Prompt(
            //        new SelectionPrompt<string>()
            //            .Title("Choose what you want to do:")
            //            .AddChoices("Enter Equipment", "Enter Components", "View Equipment", "View Components", "Update Equipment", "Update Components", "Delete Equipment", "Delete Components", "Exit"));

            //    if (mainSelection == "Enter Equipment")
            //    {
            //        EnterEquipment(IMS);
            //    }
            //    else if (mainSelection == "Enter Components")
            //    {
            //        EnterComponents(IMS);
            //    }
            //    else if (mainSelection == "View Equipment")
            //    {
            //        ViewEquipment(IMS);
            //    }
            //    else if (mainSelection == "View Components")
            //    {
            //        ViewComponents(IMS);
            //    }
            //    else if (mainSelection == "Update Equipment")
            //    {
            //        UpdateEquipment(IMS);
            //    }
            //    else if (mainSelection == "Update Components")
            //    {
            //        UpdateComponents(IMS);
            //    }
            //    else if (mainSelection == "Delete Equipment")
            //    {
            //        DeleteEquipment(IMS);
            //    }
            //    else if (mainSelection == "Delete Components")
            //    {
            //        DeleteComponents(IMS);
            //    }
            //    else if (mainSelection == "Exit")
            //    {
            //        break;
            //    }
            //}

            //AnsiConsole.MarkupLine("\n[italic]Press any key to exit...[/]");
            //Console.ReadKey(true);
        }


        //public static void EnterEquipment(InventoryManagementSystem IMS)
        //{
        //    while (true)
        //    {
        //        AnsiConsole.Clear();
        //        AnsiConsole.Write(new FigletText("Equipment").Centered().Color(Color.Green));

        //        var name = AnsiConsole.Ask<string>("Enter the [green]Name[/]:");
        //        var id = AnsiConsole.Ask<string>("Enter the [green]ID[/]:");
        //        var dop = AnsiConsole.Ask<string>("Enter the [green]Date of Purchase (DoP)[/]:");
        //        var installationDate = AnsiConsole.Ask<string>("Enter the [green]Date Installed[/]:");
        //        var decomissionedDate = AnsiConsole.Ask<string>("Enter the [green]Date Decomissioned[/]:");
        //        var updateDate = AnsiConsole.Console.Ask<string>("Enter the [green]Updated Date[/]:");
        //        var createdDate = AnsiConsole.Console.Ask<string>("Enter the [green]Created Date[/]:");


        //        var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

        //        var equipment = new EquipmentData();
        //        equipment.EquipmentName = name;
        //        equipment.EquipmentID = Convert.ToInt32(id);
        //        equipment.PurchaseDate = Convert.ToDateTime(dop);
        //        equipment.InstallationDate = Convert.ToDateTime(installationDate);
        //        equipment.EOLDate = Convert.ToDateTime(endOfLife);
        //        equipment.DecommissionedDate = Convert.ToDateTime(decomissionedDate);


        //        IMS.CreateEquipment(equipment);

        //        var continueInput = AnsiConsole.Confirm("Do you want to enter another piece of equipment?");
        //        if (!continueInput)
        //        {
        //            break;
        //        }
        //    }
        //}


        //static void ViewEquipment(InventoryManagementSystem IMS)
        //{
        //    var id = AnsiConsole.Ask<string>("Enter the [green]ID[/] of the equipment to view:");
        //    IMS.ReadEquipment(Convert.ToInt32(id));
        //}

        //static void ViewComponents(InventoryManagementSystem IMS)
        //{
        //    var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/] of the component to view:");
        //    IMS.ReadComponent(Convert.ToInt32(id));
        //}


        //static void UpdateEquipment(InventoryManagementSystem IMS)
        //{
        //    var id = AnsiConsole.Ask<string>("Enter the [green]ID[/] of the equipment to update:");

        //    var name = AnsiConsole.Ask<string>("Enter the [green]Name[/]:");
        //    var dop = AnsiConsole.Ask<string>("Enter the [green]Date of Purchase (DoP)[/]:");
        //    var installationDate = AnsiConsole.Ask<string>("Enter the [green]Date Installed[/]:");
        //    var decomissionedDate = AnsiConsole.Ask<string>("Enter the [green]Date Decomissioned[/]:");
        //    var updateDate = AnsiConsole.Console.Ask<string>("Enter the [green]Updated Date[/]:");
        //    var createdDate = AnsiConsole.Console.Ask<string>("Enter the [green]Created Date[/]:");


        //    var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

        //    var equipment = new EquipmentData();
        //    equipment.EquipmentName = name;
        //    equipment.PurchaseDate = Convert.ToDateTime(dop);
        //    equipment.InstallationDate = Convert.ToDateTime(installationDate);
        //    equipment.EOLDate = Convert.ToDateTime(endOfLife);
        //    equipment.DecommissionedDate = Convert.ToDateTime(decomissionedDate);

        //    IMS.UpdateEquipment(Convert.ToInt32(id), equipment);
        //}

        //static void UpdateComponents(InventoryManagementSystem IMS)
        //{
        //    var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/] of the component to update:");

        //    var name = AnsiConsole.Ask<string>("Enter the [green]Name[/]:");
        //    var dop = AnsiConsole.Ask<string>("Enter the [green]Date of Purchase (DoP)[/]:");
        //    var installationDate = AnsiConsole.Ask<string>("Enter the [green]Date Installed[/]:");
        //    var decomissionedDate = AnsiConsole.Ask<string>("Enter the [green]Date Decomissioned[/]:");
        //    var updateDate = AnsiConsole.Console.Ask<string>("Enter the [green]Updated Date[/]:");
        //    var createdDate = AnsiConsole.Console.Ask<string>("Enter the [green]Created Date[/]:");


        //    var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

        //    var component = new ComponentData();
        //    component.ComponentID = Convert.ToInt32(id);
        //    component.PurchaseDate = Convert.ToDateTime(dop);
        //    component.ComponentName = name;
        //    component.InstallationDate = Convert.ToDateTime(installationDate);
        //    component.EndOLDate = Convert.ToDateTime(endOfLife);
        //    component.DecommissionedDate = Convert.ToDateTime(decomissionedDate);

        //    IMS.UpdateComponent(Convert.ToInt32(id), component);

        //}
        //static void DeleteEquipment(InventoryManagementSystem IMS)
        //{
        //    var id = AnsiConsole.Ask<string>("Enter the [green]ID[/] of the equipment to delete:");
        //    IMS.DeleteEquipment(Convert.ToInt32(id));
        //}

        //static void DeleteComponents(InventoryManagementSystem IMS)
        //{
        //    var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/] of the component to delete:");
        //    IMS.DeleteComponent(Convert.ToInt32(id));
        //}



        //static void EnterComponents(InventoryManagementSystem IMS)
        //{
        //    while (true)
        //    {
        //        AnsiConsole.Clear();
        //        AnsiConsole.Write(new FigletText("Components").Centered().Color(Color.Blue));

        //        var name = AnsiConsole.Ask<string>("Enter the [blue]Name[/]:");
        //        var id = AnsiConsole.Ask<string>("Enter the [blue]ID[/]:");
        //        var dop = AnsiConsole.Ask<string>("Enter the [blue]Date of Purchase (DoP)[/]:");
        //        var installationDate = AnsiConsole.Ask<string>("Enter the [blue]Date Installed[/]:");
        //        var decomissionedDate = AnsiConsole.Ask<string>("Enter the [blue]Date Decomissioned[/]:");
        //        var updateDate = AnsiConsole.Console.Ask<string>("Enter the [blue]Updated Date[/]:");
        //        var createdDate = AnsiConsole.Console.Ask<string>("Enter the [blue]Created Date[/]:");


        //        var endOfLife = AnsiConsole.Ask<string>("Enter the [green]End of Life[/]:");

        //        var component = new ComponentData();
        //        component.ComponentName = name;
        //        component.ComponentID = Convert.ToInt32(id);
        //        component.PurchaseDate = Convert.ToDateTime(dop);
        //        component.InstallationDate = Convert.ToDateTime(installationDate);
        //        component.EndOLDate = Convert.ToDateTime(endOfLife);
        //        component.DecommissionedDate = Convert.ToDateTime(decomissionedDate);


        //        IMS.CreateComponent(component);

        //        var continueInput = AnsiConsole.Confirm("Do you want to enter another component?");
        //        if (!continueInput)
        //        {
        //            break;
        //        }
        //    }
        //}
    }

}
    