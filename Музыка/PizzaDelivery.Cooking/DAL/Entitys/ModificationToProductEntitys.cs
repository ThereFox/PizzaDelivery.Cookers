namespace DAL.Entitys;

public class ModificationToProductEntitys
{
    public Guid Id { get; set; }
    public Guid CookingProductId { get; set; }
    public Guid ModificationId { get; set; }
    
    public CookingProductsEntity ProductEntity { get; set; }
    public ModificationsEntitys ModificationEntitys { get; set; }
}