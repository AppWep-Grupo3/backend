using AutoMapper;
using BackendXComponent.ComponentX.Domain.Services.Communication;
using BackendXComponent.ComponentX.Resources;
using BackendXComponent.ComponentX.Domain.Models;
using BackendXComponent.Shared.Extensions;

namespace BackendXComponent.ComponentX.Controllers;
using Microsoft.AspNetCore.Mvc;
[ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ImplCartService _cartService; // Asegúrate de que el servicio se llame ICartService
        private readonly IMapper _mapper;

        public CartController(ImplCartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartResource>>> GetAllAsync()
        {
            var carts = await _cartService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Cart>, IEnumerable<CartResource>>(carts);
            return Ok(resources);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCartResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cart = _mapper.Map<SaveCartResource, Cart>(resource);
            
            //cart.TotalPrice = cart.Quantity * cart.SubproductId.Price;
            
            var result = await _cartService.SaveAsync(cart);

            if (!result.Success)
                return BadRequest(result.Message);

            var cartResource = _mapper.Map<Cart, CartResource>(result.Resource);
            return Ok(cartResource);
        }

        /*
                 [HttpGet("{id}")]
        public async Task<ActionResult<CartResource>> GetAsync(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = _mapper.Map<SaveCartResource, Cart>();
            var result = await _userService.UpdateAsync(id, user);
        
            if (!result.Success)
                return BadRequest(result.Message);
        
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
         */
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCartResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cart = _mapper.Map<SaveCartResource, Cart>(resource);
            var result = await _cartService.UpdateAsync(id, cart);

            if (!result.Success)
                return BadRequest(result.Message);

            var cartResource = _mapper.Map<Cart, CartResource>(result.Resource);
            return Ok(cartResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _cartService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var cartResource = _mapper.Map<Cart, CartResource>(result.Resource);
            return Ok(cartResource);
        }
    }