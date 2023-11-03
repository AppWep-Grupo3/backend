using BackendXComponent.ComponentX.Domain.Models;

namespace BackendXComponent.ComponentX.Domain.Repositories;

public interface ImplCartRepository
{
    Task<IEnumerable<Cart>> ListAsync();
    Task AddAsync(Cart cart);
    Task<Cart> FindByIdAsync(int id);
    void Update(Cart cart);
    void Remove(Cart cart);
}