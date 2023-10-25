using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Models;
using Product.Api.Repository.Implements.Auth;
using Product.Api.Repository.Implements;
using Product.Api.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Product.Api.Dto;

namespace Product.Api.Controllers
{
    [Route("ProductApi/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet("Item/{Id}"), Authorize]
        public async Task<IActionResult> GetAll(int Id)
        {
            try
            {
                IEnumerable<Item> hasil;
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    hasil = await _uow.ItemRepository.GetAll(Id);
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
        [HttpPost("Item/{Id}"), Authorize]
        public async Task<IActionResult> Save(CheklistDto Name,int Id)
        {
            try
            {
                Item hasil;
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    hasil = await _uow.ItemRepository.Save(Name, Id);
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
        [HttpGet("Item/{ItemId}/CheklistId/{Id}"), Authorize]
        public async Task<IActionResult> Get(int Id,int ItemId)
        {
            try
            {
                ItemDto hasil;
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    hasil = await _uow.ItemRepository.Get(Id,ItemId);
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
        [HttpPut("Item/{ItemId}/CheklistId/{Id}"), Authorize]
        public async Task<IActionResult> Update(int Id, int ItemId)
        {
            try
            {
                Item hasil;
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    hasil = await _uow.ItemRepository.Update(Id, ItemId);
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
        [HttpDelete("Item/{ItemId}/CheklistId/{Id}"), Authorize]
        public async Task<IActionResult> Delete(int Id, int ItemId)
        {
            try
            {
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    await _uow.ItemRepository.Delete(Id, ItemId);
                }

                var st2 = StTrans.SetSt(200, 0, "Data Berhasil Di Hapus");
                return Ok(new { Status = st2 });
            }
            catch (Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                return Ok(new { Status = st });
            }
        }
        [HttpPut("Item/{ItemId}/CheklistId/{Id}"), Authorize]
        public async Task<IActionResult> Update(int Id, int ItemId, CheklistDto Name)
        {
            try
            {
                Item hasil;
                using (IDapperContext _context = new DapperContext())
                {
                    var _uow = new UnitOfWork(_context);
                    hasil = await _uow.ItemRepository.Update(Id, ItemId, Name);
                }

                var st2 = StTrans.SetSt(200, 0, "Update Sucses");
                return Ok(new { Status = st2, Results = hasil });
            }
            catch (Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                return Ok(new { Status = st });
            }
        }
    }
}
