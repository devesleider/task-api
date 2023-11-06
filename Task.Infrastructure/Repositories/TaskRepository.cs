using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;
using Task.Core.Entities;
using Task.Core.Entities.Configurations;

namespace Task.Infrastructure.Repositories
{
    public class TaskRepository
    {
        private readonly GlobalSettings _settings;
        public TaskRepository(GlobalSettings globalSettings)
        {
            _settings = globalSettings;
        }

        public async Task<bool> Save(TaskDto task)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_settings.ConnectionStrings))
                {
                    var procedure = "dbo.SP_Save_Task";
                    conn.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@title", task.title, DbType.String, ParameterDirection.Input);
                    parameters.Add("@categorie", task.categorie, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@categorie", task.categorie, DbType.Int32, ParameterDirection.Input);
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
            return false;
        }
    }
}
