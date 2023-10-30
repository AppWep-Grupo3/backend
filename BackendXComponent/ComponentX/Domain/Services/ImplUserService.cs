using BackendXComponent.ComponentX.Domain.Models;
using BackendXComponent.ComponentX.Domain.Services.Communication.Communication;

namespace BackendXComponent.ComponentX.Domain.Services.Communication;

public interface ImplUserService
{
    Task<IEnumerable<User>> ListAsync();
    
    Task<UserResponse> SaveAsync(User user);
    
    Task<UserResponse> UpdateAsync(int id, User user);
    
    Task<UserResponse> DeleteAsync(int id);
}