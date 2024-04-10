namespace DAL.Entitys;

public class Modifications
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<CookingProducts> UsedInCookingOrders { get; set; }
    public List<ModificationContainings> ContainingIngridients { get; set; }
}