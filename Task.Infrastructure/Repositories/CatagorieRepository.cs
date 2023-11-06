using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;
using Task.Core.Entities.Configurations;
using Task.Core.Interfaces;

namespace Task.Infrastructure.Repositories
{
    public class CatagorieRepository: ICategorieRepository
    {
        private readonly GlobalSettings _settings;
        public CatagorieRepository(GlobalSettings globalSettings)
        {
            _settings = globalSettings;
        }

        public async Task<IEnumerable<Categorie>> GetAll()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_settings.ConnectionStrings))
                {
                    var procedure = "dbo.SP_Get_All_Categories";
                    conn.Open();
                    var categories = await conn.QueryAsync<Categorie>(procedure, param: null, commandType: CommandType.StoredProcedure);
                    return categories;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
