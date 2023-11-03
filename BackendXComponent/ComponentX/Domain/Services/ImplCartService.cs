using BackendXComponent.ComponentX.Domain.Models;
using BackendXComponent.ComponentX.Domain.Services.Communication.Communication;

namespace BackendXComponent.ComponentX.Domain.Services.Communication;

public interface ImplCartService
{
    Task<IEnumerable<Cart>> ListAsync();
    
    Task<CartResponse> SaveAsync(Cart cart);
    
    Task<CartResponse> UpdateAsync(int id, Cart cart);
    
    Task<CartResponse> DeleteAsync(int id); 
}