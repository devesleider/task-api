using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Core.Interfaces;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieRepository _repository;

        public CategorieController (ICategorieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }
    }
}
