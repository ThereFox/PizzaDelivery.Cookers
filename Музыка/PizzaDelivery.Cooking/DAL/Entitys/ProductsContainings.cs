namespace DAL.Entitys;

public class ProductsContainings
{
    public Guid Id { get; set; }
    
    public int Weight { get; set; }
    
    public Guid ProductId { get; set; }
    public Guid IngridientId { get; set; }
    
    public Products Product { get; set; }
    public Ingridients Ingridient { get; set; }
}