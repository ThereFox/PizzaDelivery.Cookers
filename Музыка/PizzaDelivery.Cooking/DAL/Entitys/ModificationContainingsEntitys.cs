namespace DAL.Entitys;

public class ModificationContainingsEntitys
{
    public Guid Id { get; set; }
    
    public int ContainingWeight { get; set; }
    
    
    public Guid ModificationId { get; set; }
    public Guid IngridientId { get; set; }
    
    public ModificationsEntitys ModificationEntitys { get; set; }
    public IngridientsEntity IngridientEntity { get; set; }
}