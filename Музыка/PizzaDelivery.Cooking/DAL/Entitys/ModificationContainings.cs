namespace DAL.Entitys;

public class ModificationContainings
{
    public Guid Id { get; set; }
    
    public int ContainingWeight { get; set; }
    
    public Guid ModificationId { get; set; }
    public Guid IngridientId { get; set; }
    
}