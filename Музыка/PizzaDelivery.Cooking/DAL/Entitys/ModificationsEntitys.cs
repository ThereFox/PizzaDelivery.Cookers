namespace DAL.Entitys;

public class ModificationsEntitys
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<ModificationToProductEntitys> UsedInCookingOrders { get; set; }
    public List<ModificationContainingsEntitys> ContainingIngridients { get; set; }
}