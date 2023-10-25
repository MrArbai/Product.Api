using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Product.Api.Dto;
using Product.Api.Models;
using Product.Api.Repository.Implements.Auth;
using Product.Api.Repository.Implements;
using Product.Api.Repository.Interfaces.Auth;
using Product.Api.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Product.Api.Controllers
{
    [Route("ProductApi/[controller]")]
    [ApiController]
    public class CheklistController : ControllerBase
    {
        [HttpGet("Cheklist"), Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Cheklist> hasil;
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    hasil = await _uow.CheklistRepository.GetAll();
                }

                var st2 = StTrans.SetSt(200, 0, "Data di temukan");
                return Ok(new { Status = st2, Results = hasil });
            }
            catch (Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                return Ok(new { Status = st });
            }
        }
        [HttpPost("Cheklist"), Authorize]
        public async Task<IActionResult> Save(string Name)
        {
            try
            {
                Cheklist hasil;
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    hasil = await _uow.CheklistRepository.Save(Name);
                }

                var st2 = StTrans.SetSt(200, 0, "Data di temukan");
                return Ok(new { Status = st2, Results = hasil });
            }
            catch (Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                return Ok(new { Status = st });
            }
        }
        [HttpPost("Cheklist/{Id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    await _uow.CheklistRepository.Delete(id);
                }

                var st2 = StTrans.SetSt(200, 0, "Data Berhasil Di hapus");
                return Ok(new { Status = st2 });
            }
            catch (Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                return Ok(new { Status = st });
            }
        }
    }
}