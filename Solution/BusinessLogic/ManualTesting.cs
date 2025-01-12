using CSharpFinal.Entities;
using CSharpFinal.Adapters;
using CSharpFinal.InventorySystem;


//determing if an equipment if close to its End of Life
Equipments equipment = new Equipments
{
    EquipmentID = 1,
    EquipmentName = "Server",
    PurchaseDate = DateTime.Now.AddYears(-5),
    EOLDate = DateTime.Now.AddMonths(1) // End of life in 1 month
};

bool isCloseToEOL = equipment.EquipmentsCloseToEOL();
Console.WriteLine($"Is equipment close to EOL: {isCloseToEOL}");


//listing all components near their end of life
InventoryManagementSystem ims = new InventoryManagementSystem();
Components component1 = new Components
{
    ComponentID = 1,
    ComponentName = "Hard Drive",
    EndOLDate = DateTime.Now.AddMonths(1) // Near EOL
};
Components component2 = new Components
{
    ComponentID = 2,
    ComponentName = "Memory Module",
    EndOLDate = DateTime.Now.AddYears(1) // Not near EOL
};

ims.addComponent(component1);
ims.addComponent(component2);

List<Components> nearEOLComponents = ims.componentsNearEndOfLife();
Console.WriteLine("Components near End of Life:");
foreach (var component in nearEOLComponents)
{
    Console.WriteLine($"ComponentID: {component.ComponentID}, Name: {component.ComponentName}");
}


//adding a new equipment to the inventory
Equipments newEquipment = new Equipments
{
    EquipmentID = 101,
    EquipmentName = "Router",
    PurchaseDate = DateTime.Now.AddYears(-2),
    EOLDate = DateTime.Now.AddYears(3)
};
ims.addEquipment(newEquipment);
Console.WriteLine("New equipment added.");


//deleting an equipment
ims.deleteEquipment(101); // Deletes equipment with ID 101
ims.deleteComponent(1);   // Deletes component with ID 1


//Checking if a component is in use: 
Components inUseComponent = new Components
{
    ComponentID = 3,
    ComponentName = "Power Supply",
    DecommissionedDate = null // Active component
};

bool isInUse = inUseComponent.InUse();
Console.WriteLine($"Is component in use: {isInUse}");
