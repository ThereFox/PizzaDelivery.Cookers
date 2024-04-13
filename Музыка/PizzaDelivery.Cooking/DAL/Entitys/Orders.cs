namespace DAL.Entitys;

public class Orders
{
    public Guid Id { get; set; }
    
    public int State { get; set; }
    public string Code { get; set; }
    public DateTime OrderTime { get; set; }
    
    public Guid RestoraneId { get; set; }
    
    public Restorans Restoran { get; set; }
    public List<CookingProducts> Elements { get; set; }
}