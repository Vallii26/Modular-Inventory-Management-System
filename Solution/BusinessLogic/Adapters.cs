namespace CSharpFinal.Adapters;

/// <summary>
/// This class represents the data for an equipment that the interfaces can use.
/// </summary>
public class EquipmentData
{
    public int EquipmentID { get; set; }
    public string? EquipmentName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime? InstallationDate { get; set; }
    public DateTime EOLDate { get; set; }
    public DateTime? DecommissionedDate { get; set; }
    public DateTime? updatedDate { get; set; }
    public DateTime? createdDate { get; set; }
    public List<ComponentData>? Components { get; set; }

}

/// <summary>
/// This class represents the component's data the the interfaces uses.
/// </summary>
public class ComponentData
{
    public int ComponentID { get; set; }
    public string? ComponentName { get; set; }
    public string? SubTableName { get; set; }
    public string? CompDescriptionType { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DateTime? InstallationDate { get; set; }
    public DateTime? EndOLDate { get; set; }
    public DateTime? DecommissionedDate { get; set; }
    public DateTime? updatedDate { get; set; }
    public DateTime? createdDate { get; set; }
    public string Name { get; set; }
}


/// <summary>
/// Defines the methods required for database operations related to equipment and components.
/// </summary>
public interface IDatabaseAdapter
{
    //Equipement methods.
    void CreateEquipment(EquipmentData equipment);
    EquipmentData ReadEquipment(int equipID);
    void UpdateEquipment(int equipID, EquipmentData equipment);
    void DeleteEquipment(int equipID);
    List<EquipmentData> ReadAllEquipments();

    //Component methods.
    void CreateComponent(ComponentData component);
    ComponentData ReadComponent(int compID);
    void UpdateComponent(int compID, ComponentData component);
    void DeleteComponent(int compID);
    List<ComponentData> ReadAllComponets();
}


/// <summary>
/// Defines the methods for exporting equipment and component data to CSV format.
/// </summary>
public interface IExportAdapter
{
    void ExportEquipmentToCSV(List<EquipmentData> equipmentList);
    void ExportComponentToCSV(List<ComponentData> componentList);
}


/// <summary>
/// Defines the methods for input operations related to equipment and components.
/// </summary>
public interface IInputAdapter
{
    //Equipement methods.
    void CreateEquipment(EquipmentData equipment);

    EquipmentData ReadEquipment(int equipID);
    void UpdateEquipment(int equipID, EquipmentData equipment);
    void DeleteEquipment(int equipID);
    List<EquipmentData> ReadAllEquipments();

    //Component methods.
    void CreateComponent(ComponentData component);
    ComponentData ReadComponent(int compID);
    void UpdateComponent(int compID, ComponentData component);
    void DeleteComponent(int compID);
    List<ComponentData> ReadAllComponets();
}


/// <summary>
/// Defines the methods for displaying equipment and component data to the user.
/// </summary>
public interface IOutputAdatper
{
    //Equipement methods.
    void DisplayCreateEquipmentPage(EquipmentData equipment);
    EquipmentData DisplayViewEquipmentPage(int EquipID);
    void DisplayUpdateEquipmentPage(int equipID, EquipmentData equipment);
    void DisplayDeleteEquipmentPage(int equipID);
    List<EquipmentData> ReadAllEquipmentPage();

    //Component methods.
    void DisplayCreateComponentPage(ComponentData component);
    ComponentData DisplayViewComponentPage(int compID);
    void DisplayUpdateComponentPage(int compID, ComponentData component);
    void DisplayDeleteComponentPage(int compID);
    List<ComponentData> ReadAllComponetPage();


}
