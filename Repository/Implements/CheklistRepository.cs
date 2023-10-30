using Dapper;
using Dapper.Contrib.Extensions;
using Product.Api.Dto;
using Product.Api.Models;
using Product.Api.Repository.Interfaces;

namespace Product.Api.Repository.Implements
{
    internal class CheklistRepository : ICheklistRepository
    {
        private readonly IDapperContext _context;
        // private ILog _log;

        public CheklistRepository(IDapperContext context)
        {
            _context = context;
            // _log = log;
        }

        public async Task Delete(int id)
        {
            try
            {
                var obj = await Task.Run(() => _context.Db.Get<Cheklist>(id));
                await Task.Run(() => _context.Db.Delete(obj));

            }
            catch (Exception ex)
            {
                throw new Exception("Save" + ex.Message);
            }
        }

        public async Task<IEnumerable<Cheklist>> GetAll()
        {
            try
            {
                var Item = await Task.Run(() => _context.Db.GetAll<Cheklist>());
                return Item;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAll" + ex.Message);
            }
        }

        public async Task<Cheklist> Save(CheklistDto name)
        {
            try
            {
                Cheklist obj = new()
                {
                    Name = name.Name
                };
                await Task.Run(() => _context.Db.Insert(obj));
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Save" + ex.Message);
            }
        }
    }
}