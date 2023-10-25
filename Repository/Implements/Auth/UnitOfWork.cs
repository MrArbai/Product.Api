using Product.Api.Repository.Implements.Auth;
using Product.Api.Repository.Interfaces;
using Product.Api.Repository.Interfaces.Auth;

namespace Product.Api.Repository.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDapperContext _context;
        private IAuthRepository _authRepository;
      
        public UnitOfWork(IDapperContext context)
        {
            _context = context;
        }

        // ============== Repository =================
        public IAuthRepository AuthRepository {
            get { return _authRepository ??= new AuthRepository(_context); }
        }
       
    }
}   