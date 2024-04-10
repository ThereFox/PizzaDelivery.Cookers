namespace DAL.Entitys;

public class Cookers
{
    public Guid Id { get; set; }
    public Guid RestoraneId { get; set; }
    public string Name { get; set; }
    
    public Restorans Restoran { get; set; }
    public List<CookingProducts> CookingProducts { get; set; }
}