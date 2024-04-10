namespace DAL.Entitys;

public class Products
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<CookingProducts> Cookings { get; set; }
    public List<ProductsContainings> IngridientContaining { get; set; }
}