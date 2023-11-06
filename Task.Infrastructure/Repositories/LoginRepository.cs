using System.Data.SqlClient;
using System.Data;
using System;
using System.Threading.Tasks;
using Task.Core.DTOs;
using Task.Core.Entities.Configurations;
using Task.Core.Interfaces;
using Dapper;
using Task.Core.Entities;
using System.Linq;

namespace Task.Infrastructure.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly GlobalSettings _settings;
        public LoginRepository(GlobalSettings globalSettings) {
            _settings = globalSettings;
        }

        public async Task<User> Login(LoginDto login)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_settings.ConnectionStrings))
                {
                    var procedure = "dbo.SP_Login";
                    conn.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@user", login.email, DbType.String, ParameterDirection.Input);
                    parameters.Add("@password", login.password, DbType.String, ParameterDirection.Input);
                    var res = await conn.QueryAsync<User>(procedure, param: parameters, commandType: CommandType.StoredProcedure);

                    return res.FirstOrDefault();
                    // Ahora puedes usar la variable "result" para tomar decisiones basadas en el valor booleano.
                    //if (result == 1)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
