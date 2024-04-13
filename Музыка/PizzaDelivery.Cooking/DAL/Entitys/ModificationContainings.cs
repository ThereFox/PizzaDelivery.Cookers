namespace DAL.Entitys;

public class ModificationContainings
{
    public Guid Id { get; set; }
    
    public int ContainingWeight { get; set; }
    
    
    public Guid ModificationId { get; set; }
    public Guid IngridientId { get; set; }
    
    public Modifications Modification { get; set; }
    public Ingridients Ingridient { get; set; }
}