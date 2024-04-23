namespace DAL.Entitys;

public class IngridientsEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<ModificationContainingsEntitys> ContainingInModifications { get; set; }
    public List<ProductsContainingsEntitys> ContainingInProducts { get; set; }
    public List<RestoraneStocksDBEntity> StocksInRestorans { get; set; }
}