using Product.Api.Dto;
using Product.Api.Models;

namespace Product.Api.Repository.Interfaces
{
    public interface IItemRepsitory
    {
        Task<IEnumerable<Item>> GetAll(int Id);
        Task<Item> Save(CheklistDto Name,int Id);
        Task Delete(int id);
        Task<ItemDto> Get(int Id, int ItemId);
        Task<Item> Update(int Id, int ItemId);
        Task Delete(int Id, int ItemId);
        Task<Item> Update(int Id, int ItemId, CheklistDto Name);
    }
}
