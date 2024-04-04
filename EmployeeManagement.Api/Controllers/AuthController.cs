using AutoMapper;
using EmployeeManagement.Api.Models;
using Employees.Core.DTOs;
using Employees.Core.Entites;
using Employees.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _service;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, IAuthService service, IMapper mapper)
        {
            _configuration = configuration;
            _service = service;
            _mapper = mapper;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDetailsPostModel login)
        {
            var result = await _service.Login(login.UserName, login.Password);
            if (result == null)
                return Unauthorized();

            //var claims = new List<Claim>()
            //{
            //    new Claim(ClaimTypes.Name , result.Name)
            //};

            //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            //var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            //var tokeOptions = new JwtSecurityToken(
            //    issuer: _configuration.GetValue<string>("JWT:Issuer"),
            //    audience: _configuration.GetValue<string>("JWT:Audience"),
            //    claims: claims,
            //    expires: DateTime.Now.AddMinutes(6),
            //    signingCredentials: signinCredentials
            //);

            //var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            var tokenString = CreateJwtToken(result);
            return Ok(new { Token = tokenString, Company = _mapper.Map<CompanyDetailsDto>(result) });

        }


        [HttpPost("register")]
        public async Task<ActionResult> Post([FromBody] CompanyPostModel company, int termsId)
        {
            var comp = new Company()
            {
                Name = company.Name,
                Password = company.Password,
                UserName = company.UserName,
                Address = company.Address,
                Description = company.Description,
                Email = company.Email,
                Manager = company.Manager,
                TermsId = termsId,
            };
            var result = await _service.RegisterAsync(comp);
            if (result == null)
                return NotFound();//check which status code is fit here.
            //return Ok(_mapper.Map<CompanyDto>(result));

            var tokenString = CreateJwtToken(result);
            return Ok(new { Token = tokenString, Company = _mapper.Map<CompanyDetailsDto>(result) });
        }

        private string CreateJwtToken(Company company)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , company.Name)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
