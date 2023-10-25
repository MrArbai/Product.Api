using Product.Api.Repository.Interfaces.Auth;

namespace Product.Api.Repository.Interfaces
{
    public interface IUnitOfWork 
    {
        IAuthRepository AuthRepository { get; }
    }
}