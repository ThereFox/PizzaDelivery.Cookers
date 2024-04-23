namespace DAL.Entitys;

public class ProductsTechCardDBEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<CookingProductsEntity> Cookings { get; set; }
    public List<ProductsContainingsEntitys> IngridientContaining { get; set; }
}