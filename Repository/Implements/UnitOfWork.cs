using Product.Api.Repository.Interfaces;
using Product.Api.Repository.Interfaces.Auth;
using Product.Api.Repository.Interfaces;

namespace Product.Api.Repository.Implements.Auth
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDapperContext _context;
        private IAuthRepository _authRepository;
        private ICheklistRepository _cheklistRepository;
        private IItemRepsitory _itemRepository;

        public UnitOfWork(IDapperContext context)
        {
            _context = context;
        }

        // ============== Repository =================
        public IAuthRepository AuthRepository
        {
            get { return _authRepository ??= new AuthRepository(_context); }
        }
        public ICheklistRepository CheklistRepository
        {
            get { return _cheklistRepository ??= new CheklistRepository(_context); }
        }
        public IItemRepsitory ItemRepository
        {
            get { return _itemRepository ??= new ItemRepsitory(_context); }
        }


    }
}