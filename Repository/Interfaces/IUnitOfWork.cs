namespace Product.Api.Repository.Interfaces.Auth
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        ICheklistRepository CheklistRepository { get; }
    }
}