using CSharpFinal.Adapters;
using CSharpFinal.InventorySystem;
using CSharpFinal.DataBaseLibrary;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages support
builder.Services.AddRazorPages();

var OutputAdapter = new ASPAdapterUI();
var DbAdapter = new SQLiteAdapter();
var IMS = new InventoryManagementSystem(DbAdapter, OutputAdapter);

// Register the dependency implementations
builder.Services.AddSingleton<IInputAdapter>(s => IMS);
builder.Services.AddSingleton<IOutputAdatper>(s => OutputAdapter);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();

public class ASPAdapterUI : IOutputAdatper
{
    public string url { get; set; }
    public void DisplayCreateComponentPage(ComponentData component)
    {

    }

    public void DisplayCreateEquipmentPage(EquipmentData equipment)
    {

    }

    public void DisplayDeleteComponentPage(int compID)
    {

    }

    public void DisplayDeleteEquipmentPage(int equipID)
    {

    }

    public void DisplayUpdateComponentPage(int compID, ComponentData component)
    {

    }

    public void DisplayUpdateEquipmentPage(int equipID, EquipmentData equipment)
    {

    }

    public ComponentData DisplayViewComponentPage(int compID)
    {
        return new ComponentData();
    }

    public EquipmentData DisplayViewEquipmentPage(int EquipID)
    {
        return new EquipmentData();
    }

    public List<ComponentData> ReadAllComponetPage()
    {
        return new List<ComponentData>();
    }

    public List<EquipmentData> ReadAllEquipmentPage()
    {
        return new List<EquipmentData>();
    }
}