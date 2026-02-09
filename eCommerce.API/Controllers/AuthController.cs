using eCommerce.Core.DTOs;
using eCommerce.Core.Entities.ServiceContracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")] //api/auth/register
        public async Task<IActionResult> Register(RegisterRequest registerRequest, IValidator<RegisterRequest> validator)
        {
            //FluentValidations
            var validationResult = await validator.ValidateAsync(registerRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            if (registerRequest == null || string.IsNullOrEmpty(registerRequest.Email) || string.IsNullOrEmpty(registerRequest.Password))
            {
                return BadRequest("Invalid registration data. Please provide email and password.");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Register(registerRequest);
            if (authenticationResponse == null || !authenticationResponse.Success)
            {
                //return BadRequest("Registration failed. Please try again.");
                return BadRequest(authenticationResponse);
            }
            //return Ok("Registration successful.");
            return Ok(authenticationResponse);
        }

        [HttpPost("login")] //api/auth/login
        public async Task<IActionResult> Login(LoginRequest loginRequest, IValidator<LoginRequest> validator)
        {
            //FluentValidations
            var validationResult = await validator.ValidateAsync(loginRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid login data. Please provide email and password.");
            }
            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);
            if (authenticationResponse == null || authenticationResponse.Token == null)
            {
                return Unauthorized(authenticationResponse);
            }
            //return Ok(new { Token = authenticationResponse.Token });
            return Ok(authenticationResponse);
        }
    }
}
