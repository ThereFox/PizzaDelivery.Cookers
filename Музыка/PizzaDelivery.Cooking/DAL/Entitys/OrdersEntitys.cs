namespace DAL.Entitys;

public class OrdersEntitys
{
    public Guid Id { get; set; }
    
    public int State { get; set; }
    public string Code { get; set; }
    public DateTime OrderTime { get; set; }
    
    public Guid RestoraneId { get; set; }
    
    public RestoransDBEntity RestoranDbEntity { get; set; }
    public List<CookingProductsEntity> Elements { get; set; }
}