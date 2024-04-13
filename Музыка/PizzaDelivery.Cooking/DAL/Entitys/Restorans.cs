namespace DAL.Entitys;

public class Restorans
{
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public DateTime StartWorkingTime { get; set; }
    public DateTime StopWorkingTime { get; set; }
    
    public List<Cookers> Workers { get; set; }
    public List<Orders> Orders { get; set; }
    public List<Stocks> StocksList { get; set; }
}