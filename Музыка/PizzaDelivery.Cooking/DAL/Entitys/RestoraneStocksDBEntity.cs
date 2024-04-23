namespace DAL.Entitys;

public class RestoraneStocksDBEntity
{
     public Guid Id { get; set; }
     
     public Guid RestoraneId { get; set; }
     public Guid IngridientId { get; set; }

     public int Weight { get; set; }
     
     public RestoransDBEntity Restorane { get; set; }
     public IngridientsEntity Ingridient { get; set; }
}