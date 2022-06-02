using BookService.DALL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookWEBAPI.WEB.Controllers
{
    
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;

        }
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(Register register)

        {
                
            

            var user = new IdentityUser { UserName = register.UserName };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {

                return Ok(result);

            }
            return Ok(result.Errors);
        }


      
        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> LoginUser(LoginModel login)

        {


            var user = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

             if (user.Succeeded)
            {
                return Ok(user.Succeeded);
            }
            
            return BadRequest(user.IsNotAllowed);
        }

    }
}
