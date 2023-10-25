using Dapper;
using Dapper.Contrib.Extensions;
using Product.Api.Models;
using Product.Api.Repository.Interfaces;
using Product.Api.Repository.Interfaces.Auth;

namespace Product.Api.Repository.Implements.Auth
{
    internal class AuthRepository : IAuthRepository
    {
        private readonly IDapperContext _context;
        // private ILog _log;

        public AuthRepository(IDapperContext context)
        {
            _context = context;
            // _log = log;
        }
        public async Task<User> Login(string UserName, string Password)
        {
            try
            {
                var sql = string.Format(@"UPDATE MYPSG..tblMstItemGroupMaterial SET TeleSend = 1 WHERE GroupItemCode IN ({0})", UserName);
                var user = await Task.Run(() => _context.Db.QueryFirstAsync<User>(sql)) ?? throw new Exception("User Tidak terdaftar !!!");
                if (!BCrypt.Net.BCrypt.Verify(Password, user.Password))
                    throw new Exception("Password Salah, Silahkan Periksa Password Anda !!!");  

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<User> Register(User user)
        {
            string pass = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = pass;
            await Save(user);

            return user;
        }
       
        public async Task<User> Save(User obj)
        {
            await _context.Db.InsertAsync(obj);
            var user = await Task.Run(() => _context.Db.Get<User>(obj.Username));
            return user;
        }


        public async Task<bool> UserExists(string username)
        {
            if (await _context.Db.ExecuteScalarAsync<bool>("Select Count(1) From TblUser where " +
                           "Username = @userId", new { userId = username }))
                return true;

            return false;
        }

    }
}