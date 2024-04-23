namespace DAL.Entitys;

public class CookingProductsEntity
{
    public Guid Id { get; set; }
    
    public int State { get; set; }
    
    public Guid OrderId { get; set; }
    public Guid BaseProductId { get; set; }
    public Guid CookerId { get; set; }
    
    public CookersEntity CookerEntity { get; set; }
    public OrdersEntitys OrderEntitys { get; set; }
    public ProductsTechCardDBEntity BaseProductTechCardDbEntity { get; set; }
    public List<ModificationToProductEntitys> Modifications { get; set; }
    
}