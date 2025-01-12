using CSharpFinal.Adapters;
namespace CSharpFinal.InventorySystem;

    /// <summary>
    /// This class provides methods for managing equipment and components in the inventory. 
    /// </summary>
    public class InventoryManagementSystem : IInputAdapter
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryManagementSystem"/> class.
    /// </summary>
    /// <param name="dataparam">The database adapter to manage data operations.</param>
    /// <param name="outputparam">The output adapter to display results to the user.</param>
    public InventoryManagementSystem(IDatabaseAdapter dataparam, IOutputAdatper outputparam)
        {
            DatabaseConnection = dataparam;
            OutputConnection  = outputparam;
        }

    /// <summary>
    /// Gets or sets the database adapter for data operations.
    /// </summary>
    public IDatabaseAdapter DatabaseConnection { get; set; }

    /// <summary>
    /// Gets or sets the output adapter for displaying results.
    /// </summary>
    public IOutputAdatper OutputConnection { get; set; }

    /// <summary>
    /// Creates a new equipment record in the inventory.
    /// </summary>
    /// <param name="equipment">The equipment data to create.</param>
    public void CreateEquipment(EquipmentData equipment)
    {
        DatabaseConnection.CreateEquipment(equipment);
        OutputConnection.DisplayCreateEquipmentPage(equipment);
    }


    /// <summary>
    /// Reads equipment data from the inventory.
    /// </summary>
    /// <param name="equipID">The ID of the equipment to read.</param>
    /// <returns>The equipment data associated with the provided ID.</returns>
    public EquipmentData ReadEquipment(int equipID)
    {
        var equipment = DatabaseConnection.ReadEquipment(equipID);
        OutputConnection.DisplayViewEquipmentPage(equipID);
        return equipment;
    }

    /// <summary>
    /// Updates an existing equipment record in the inventory.
    /// </summary>
    /// <param name="equipID">The ID of the equipment to update.</param>
    /// <param name="equipment">The updated equipment data.</param>
    public void UpdateEquipment(int equipID, EquipmentData equipment)
    {
        DatabaseConnection.UpdateEquipment(equipID, equipment);
        OutputConnection.DisplayUpdateEquipmentPage(equipID, equipment);
    }

    /// <summary>
    /// Deletes an equipment record from the inventory.
    /// </summary>
    /// <param name="equipID">The ID of the equipment to delete.</param>
    public void DeleteEquipment(int equipID)
    {
        DatabaseConnection.DeleteEquipment(equipID);
        OutputConnection.DisplayDeleteEquipmentPage(equipID);
    }

    /// <summary>
    /// Reads all equipment records from the inventory.
    /// </summary>
    /// <returns>A list of all equipment data in the inventory.</returns>
    public List<EquipmentData> ReadAllEquipments()
    {
        var equipmentList = DatabaseConnection.ReadAllEquipments();
        return equipmentList;
    }

    /// <summary>
    /// Creates a new component record in the inventory.
    /// </summary>
    /// <param name="component">The component data to create.</param>
    public void CreateComponent(ComponentData component)
    {
        DatabaseConnection.CreateComponent(component);
        OutputConnection.DisplayCreateComponentPage(component);
    }

    /// <summary>
    /// Reads component data from the inventory.
    /// </summary>
    /// <param name="compID">The ID of the component to read.</param>
    /// <returns>The component data associated with the provided ID.</returns>
    public ComponentData ReadComponent(int compID)
    {
        var component = DatabaseConnection.ReadComponent(compID);
        OutputConnection.DisplayViewComponentPage(compID);
        return component;
    }

    /// <summary>
    /// Updates an existing component record in the inventory.
    /// </summary>
    /// <param name="compID">The ID of the component to update.</param>
    /// <param name="component">The updated component data.</param>
    public void UpdateComponent(int compID, ComponentData component)
    {
        DatabaseConnection.UpdateComponent(compID, component);
        OutputConnection.DisplayUpdateComponentPage(compID, component);

    }

    /// <summary>
    /// Deletes a component record from the inventory.
    /// </summary>
    /// <param name="compID">The ID of the component to delete.</param>
    public void DeleteComponent(int compID)
    {
        DatabaseConnection.DeleteComponent(compID);
        OutputConnection.DisplayDeleteComponentPage(compID);

    }

    /// <summary>
    /// Reads all component records from the inventory.
    /// </summary>
    /// <returns>A list of all component data in the inventory.</returns>
    public List<ComponentData> ReadAllComponets()
    {
        var component = DatabaseConnection.ReadAllComponets();
        return component;
    }
}
