using Microsoft.Data.SqlClient;
using Product.Api.Repository.Interfaces;
using System;
using System.Data;
using System.Data.Common;

namespace Product.Api.Repository.Implements
{
    public class DapperContext : IDapperContext
    {
        private IDbConnection _db;
        private readonly string _connectionString;
        
        public DapperContext()
        {
            _connectionString = "Data Source= 127.0.0.1; Initial Catalog=Product; User ID=Mifta; Password=9797; MultipleActiveResultSets=True;";

            _db ??= GetOpenConnection( _connectionString);
        }

        private IDbConnection GetOpenConnection( string connectionString)
        {
            DbConnection? conn = null;

            try
            {
                SqlClientFactory provider = SqlClientFactory.Instance;
                conn = provider.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
            }
            catch
            {
            }

            return conn;
        }

        public IDbConnection Db {
            get { return _db ??= GetOpenConnection( _connectionString); }
        }

        public IDbTransaction Transaction { get; private set; }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            Transaction ??= _db.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            Transaction?.Commit();  
        }

        public void Dispose()
        {
            if (_db != null)
            {
                try
                {
                    if (_db.State != ConnectionState.Closed)
                    {
                        Transaction?.Rollback();

                        _db.Close();
                    }                        
                }
                finally
                {
                    _db.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }

        public string GetGUID()
        {
            string result;
            try
            {
                result = Guid.NewGuid().ToString();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public void Rollback()
        {
            Transaction?.Rollback();    
        }
    }
}
