using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.Services;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    /// <summary>
    /// API controller for managing favorites.
    /// </summary>
    [ApiController]
    [Route("api/v1/favorites")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService) => _favoriteService = favoriteService;

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<FavoriteDto>>> GetByUserIdAsync(int userId) => Ok(await _favoriteService.GetFavoritesByUserIdAsync(userId));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAsync([FromBody] FavoriteDto favoriteDto)
        {
            await _favoriteService.AddFavoriteAsync(favoriteDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            await _favoriteService.RemoveFavoriteAsync(id);
            return NoContent();
        }
    }
}
