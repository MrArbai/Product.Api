using Dapper;
using Dapper.Contrib.Extensions;
using Product.Api.Dto;
using Product.Api.Models;
using Product.Api.Repository.Interfaces;
using System.Xml.Linq;

namespace Product.Api.Repository.Implements
{
    internal class ItemRepsitory : IItemRepsitory
    {
        private readonly IDapperContext _context;
        // private ILog _log;

        public ItemRepsitory(IDapperContext context)
        {
            _context = context;
            // _log = log;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAll(int Id)
        {
            try
            {
                var sql = string.Format(@"SELECT * FROM MyDB..TblItem WHERE CheklistId = '{0}'", Id);
                IEnumerable<Item> user = await Task.Run(() => _context.Db.QueryAsync<Item>(sql)) ?? throw new Exception("Item Tidak Di Temukan !!!");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Item> Save(CheklistDto Name,int id)
        {
            try
            {
                Item obj = new()
                {
                    Name = Name.Name,
                    CheklistID = id
                };
                await Task.Run(() => _context.Db.InsertAsync(obj));
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Save" + ex.Message);
            }
        }

        public async Task<ItemDto> Get(int Id,int ItemId) 
        {
            try
            {
                ItemDto obj;
                obj = await Task.Run(() => _context.Db.Get<ItemDto>(ItemId));
                obj.CheklistID = await Task.Run(() => _context.Db.Get<Cheklist>(Id));
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Save" + ex.Message);
            }
        }
        public async Task<Item> Update(int Id, int ItemId)
        {
            try
            {
                Item item;
                var sql = string.Format(@"UPDATE MyDB..TblItem SET Isactive = 1 WHERE Id = {0} AND CheklistID = {1}", ItemId, Id);
                item = (Item)await _context.Db.QueryAsync<Item>(sql);

                return item;

            }
            catch (Exception ex)
            {
                throw new Exception("Save" + ex.Message);
            }
        }
        public async Task Delete(int Id, int ItemId)
        {
            try
            {
                Item item;
                var sql = string.Format(@"DELETE MyDb..TblItem  WHERE Id = {0} AND CheklistID = {1}", ItemId, Id);
                await _context.Db.QueryAsync<Item>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Save" + ex.Message);
            }
        }
        public async Task<Item> Update(int Id, int ItemId, CheklistDto Name)
        {
            try
            {
                Item item;
                var sql = string.Format(@"UPDATE MyDB..TblItem SET Name = {0} WHERE Id = {1} AND CheklistID = {2}", ItemId, Id,Name);
                item = (Item)await _context.Db.QueryAsync<Item>(sql);

                return item;

            }
            catch (Exception ex)
            {
                throw new Exception("Save" + ex.Message);
            }
        }
    }
}