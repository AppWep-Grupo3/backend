
using BackendXComponent.ComponentX.Domain.Models;

namespace BackendXComponent.ComponentX.Resources;

public class ProductResource
{
    //Aca va lo que se va a mostrar en el response para el usuario
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Image { get; set; }
    
    public decimal Price { get; set; }
    
    public string SpecificDetails { get; set; }
    
    public string GeneralDetails { get; set; }
    

    public IList<SubProduct> SubProductsList { get; set; } = new List<SubProduct>();
}