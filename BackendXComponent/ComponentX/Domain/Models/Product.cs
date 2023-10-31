namespace BackendXComponent.ComponentX.Domain.Models;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Image { get; set; }
    
    public decimal Price { get; set; }
    
    public string SpecificDetails { get; set; }
    
    public string GeneralDetails { get; set; }
    
    public IList<SubProduct> SubProductsList { get; set; } = new List<SubProduct>();
    //de esta manera estableecemmos la relacion de asociacion de uno a muchos
}