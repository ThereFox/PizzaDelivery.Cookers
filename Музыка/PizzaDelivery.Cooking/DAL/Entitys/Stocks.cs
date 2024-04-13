namespace DAL.Entitys;

public class Stocks
{
     public Guid Id { get; set; }
     
     public Guid RestoraneId { get; set; }
     public Guid IngridientId { get; set; }

     public int Weight { get; set; }
     
     public Restorans Restoran { get; set; }
     public Ingridients Ingridient { get; set; }
}