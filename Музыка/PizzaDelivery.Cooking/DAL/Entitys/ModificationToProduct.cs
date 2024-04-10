namespace DAL.Entitys;

public class ModificationToProduct
{
    public Guid Id { get; set; }
    public Guid CookingProductId { get; set; }
    public Guid ModificationId { get; set; }
    
    public CookingProducts Product { get; set; }
    public Modifications Modification { get; set; }
}