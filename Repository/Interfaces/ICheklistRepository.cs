using Microsoft.AspNetCore.Identity;
using Product.Api.Dto;
using Product.Api.Models;

namespace Product.Api.Repository.Interfaces
{
    public interface ICheklistRepository
    {

        Task<IEnumerable<Cheklist>> GetAll();
        Task<Cheklist> Save(CheklistDto Name);
        Task Delete(int id);
    }
}