using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Product.Api.Dto;
using Product.Api.Models;
using Product.Api.Repository.Implements;
using Product.Api.Repository.Implements.Auth;
using Product.Api.Repository.Interfaces;
using Product.Api.Repository.Interfaces.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Product.Api.Controllers
{
    [Route("ProductApi/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {

        private readonly IConfiguration? _config;
        private IDapperContext? _context;
        private IUnitOfWork? _uow;
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto userDto)
        {
            try
            {
                bool flag;
                using (_context = new DapperContext())
                {
                    _uow = new UnitOfWork(_context);
                    flag = await _uow.AuthRepository.UserExists(userDto.Username);
                }
                if (flag)
                {
                    var st = StTrans.SetSt(400, 0, "User Sudah Di Buat");
                    return Ok(new { Status = st });
                }

                var usercreate = new User();

                using (_context = new DapperContext())
                {
                    _uow = new UnitOfWork(_context);
                    User user = new()
                    {
                        Username = userDto.Username,
                        Email = userDto.Email,
                        Password = userDto.Password

                    };
                    usercreate = await _uow.AuthRepository.Register(user);
                }
                var st2 = StTrans.SetSt(200, 0, "User Berhasil Di Buat");
                return Ok(new { Status = st2, Results = usercreate });

            }
            catch (Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                return Ok(new { Status = st });
            }
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            try
            {
                var dt = new User();

                using (_context = new DapperContext())
                {
                    _uow = new UnitOfWork(_context);
                    dt = await _uow.AuthRepository.Login(userDto.UserName, userDto.Password);

                    dt.Token = GenerateJwtToken(dt);

                    if (dt == null)
                        return Unauthorized();

                }

                var st = StTrans.SetSt(200, 0, "User Berhasil Login");
                return Ok(new { Status = st, Results = dt });
            }
            catch (Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                return Ok(new { Status = st });
            }
        }
        private string GenerateJwtToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.PrimarySid, user.Email),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1niT0k3nr4H4s14p55@2oi9#0k3..asa!223Ac.,asd~12!@@$$#%#^^$^&%**)((W)"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
