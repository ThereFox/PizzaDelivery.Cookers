namespace DAL.Entitys;

public class CookingProducts
{
    public Guid Id { get; set; }
    
    public int State { get; set; }
    
    public Guid OrderId { get; set; }
    public Guid BaseProductId { get; set; }
    public Guid CookerId { get; set; }
    
    public Orders Order { get; set; }
    public Products BaseProduct { get; set; }
    
}