using BackendXComponent.ComponentX.Domain.Models;
using BackendXComponent.ComponentX.Domain.Services.Communication.Communication;

namespace BackendXComponent.ComponentX.Domain.Services.Communication;

public interface ImplProductService
{
    Task<IEnumerable<Product>> ListAsync();
    
    Task<ProductResponse> SaveAsync(Product product);
    
    Task<ProductResponse> UpdateAsync(int id, Product product);
    
    Task<ProductResponse> DeleteAsync(int id);
}