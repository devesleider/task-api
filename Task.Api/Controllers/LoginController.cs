using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Core.DTOs;
using Task.Core.Interfaces;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository) { 
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginDto login)
        {
            return Ok(await _loginRepository.Login(login));
        }
    }
}
