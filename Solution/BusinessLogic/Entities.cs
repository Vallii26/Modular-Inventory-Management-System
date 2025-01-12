using System.Data;

namespace CSharpFinal.Entities;

/// <summary>
/// This class represents an equipment item in the inventory system, such as a PC,
/// </summary>
public class Equipments
{
    public int EquipmentID { get; set; }
    public string? EquipmentName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime? InstallationDate { get; set; }
    public DateTime? EOLDate { get; set; }
    public DateTime? DecommissionedDate { get; set; }
    public DateTime? updatedDate { get; set; }
    public DateTime? createdDate { get; set; }
    public List<Components>? Components { get; set; }


    /// <summary>
    /// this methods checks if an equipment if close to its end-of-life date and return true or false
    /// takes one parameter: months (default = 2)
    /// </summary>
    /// <param name="months"> receives the a month param</param>
    /// <returns></returns>
    public bool EquipmentsCloseToEOL(int months = 2)
    {
        if (EOLDate.HasValue && DateTime.Now.AddMonths(months) >= EOLDate.Value)
        {
            return true;
        }
        return false;
    }
}

/// <summary>
/// this class represents a hardware component within an equipment item or in storage
/// it can be either an active or stored component. 
/// </summary>
public class Components
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


    /// <summary>
    /// This method checks if the current component is in use and returns true if it is or false if it is not
    /// it determins this by checking if the decommissionedDate has a value passed to it.
    /// </summary>
    /// <returns> returns true or false if the component is in use or not</returns>
    public bool InUse()
    {
        return !DecommissionedDate.HasValue;
    }
}