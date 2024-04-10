namespace DAL.Entitys;

public class Ingridients
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<ModificationContainings> ContainingInModifications { get; set; }
    public List<ProductsContainings> ContainingInProducts { get; set; }
    public List<Stocks> StocksInRestorans { get; set; }
}