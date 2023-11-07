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
using Task.Core.Interfaces;

namespace Task.Infrastructure.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly GlobalSettings _settings;
        public TaskRepository(GlobalSettings globalSettings)
        {
            _settings = globalSettings;
        }

        public async Task<IEnumerable<TaskE>> GetTasksByUser(int user, int categorie)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_settings.ConnectionStrings))
                {
                    var procedure = "dbo.SP_Get_Task_By_User";
                    conn.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@user", user, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@categorie", categorie, DbType.Int32, ParameterDirection.Input);
                    var tasks = await conn.QueryAsync<TaskE>(procedure, param: parameters, commandType: CommandType.StoredProcedure);
                    return tasks;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    parameters.Add("@user", task.user, DbType.String, ParameterDirection.Input);
                    parameters.Add("@deadline", task.deadline, DbType.Date, ParameterDirection.Input);
                    int result = await conn.ExecuteScalarAsync<int>(procedure, param: parameters, commandType: CommandType.StoredProcedure);

                    bool isSuccess = (result == 1);

                    return isSuccess;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(int id, bool end)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_settings.ConnectionStrings))
                {
                    var procedure = "dbo.SP_Update_Task";
                    conn.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@end", end, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);

                    int result = await conn.ExecuteScalarAsync<int>(procedure, param: parameters, commandType: CommandType.StoredProcedure);

                    bool isSuccess = (result == 1);

                    return isSuccess;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
