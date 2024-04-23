namespace DAL.Entitys;

public class CookersEntity
{
    public Guid Id { get; set; }
    
    public Guid WorkPlaseId { get; set; }
    
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    
    public RestoransDBEntity WorkPlase { get; set; }
    public List<CookingProductsEntity> CookedProducts { get; set; }
}