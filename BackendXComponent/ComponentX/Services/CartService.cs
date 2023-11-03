using BackendXComponent.ComponentX.Domain.Models;
using BackendXComponent.ComponentX.Domain.Repositories;
using BackendXComponent.ComponentX.Domain.Services.Communication;
using BackendXComponent.ComponentX.Domain.Services.Communication.Communication;

namespace BackendXComponent.ComponentX.Services;

public class CartService: ImplCartService
{
    public readonly ImplCartRepository _cartRepository;
    public readonly ImplUnitOfWork _unitOfWork;
    
    public CartService(ImplCartRepository CartRepository, ImplUnitOfWork unitOfWork)
    {
        _cartRepository = CartRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Cart>> ListAsync()
    {
      return await _cartRepository.ListAsync();
      
    }

    public async Task<CartResponse> SaveAsync(Cart cart)
    {
        try
        {
            await _cartRepository.AddAsync(cart);
            await _unitOfWork.CompleteAsync();
            return new CartResponse(cart);

        }
        catch (Exception e)
        {
            return new CartResponse($"An error occurred when saving the cart: {e.Message}");

        }
        
    }
    

    public async Task<CartResponse> UpdateAsync(int id, Cart cart)
    {
        var existingCart = await _cartRepository.FindByIdAsync(id);
        if (existingCart == null)
            return new CartResponse("Cart not found.");
        existingCart.UserId = cart.UserId;
        //existingCart.ProductID = cart.ProductID;
        existingCart.Quantity = cart.Quantity;
        existingCart.SubproductId = cart.SubproductId;
        existingCart.TotalPrice = cart.TotalPrice;
        
        try
        {
            _cartRepository.Update(existingCart);
            await _unitOfWork.CompleteAsync();
            return new CartResponse(existingCart);
        }
        catch (Exception e)
        {
            return new CartResponse($"An error occurred when updating the cart: {e.Message}");
        }
    }

    public async Task<CartResponse> DeleteAsync(int id)
    { 
        var existingCart = await _cartRepository.FindByIdAsync(id);
        if (existingCart == null)
            return new CartResponse("Cart not found.");
        try
        {
            _cartRepository.Remove(existingCart);
            await _unitOfWork.CompleteAsync();
            return new CartResponse(existingCart);
        }
        catch (Exception e)
        {
            return new CartResponse($"An error occurred when deleting the category: {e.Message}");
        }
    }
    
}