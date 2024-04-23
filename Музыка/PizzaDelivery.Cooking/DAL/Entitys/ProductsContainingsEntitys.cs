namespace DAL.Entitys;

public class ProductsContainingsEntitys
{
    public Guid Id { get; set; }
    
    public int Weight { get; set; }
    
    public Guid ProductId { get; set; }
    public Guid IngridientId { get; set; }
    
    public ProductsTechCardDBEntity ProductTechCardDbEntity { get; set; }
    public IngridientsEntity IngridientEntity { get; set; }
}