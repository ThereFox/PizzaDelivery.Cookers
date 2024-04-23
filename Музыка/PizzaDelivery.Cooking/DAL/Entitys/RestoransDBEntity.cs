namespace DAL.Entitys;

public class RestoransDBEntity
{
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public TimeOnly StartWorkingTime { get; set; }
    public TimeOnly StopWorkingTime { get; set; }
    
    public List<CookersEntity> Workers { get; set; }
    public List<OrdersEntitys> Orders { get; set; }
    public List<RestoraneStocksDBEntity> StocksList { get; set; }
}