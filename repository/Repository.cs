namespace Project.Repository
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<GetModel> GetMethod(int Id)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                DynamicParameters dParams = new DynamicParameters();
                dParams.Add("@Id", Id, DbType.Int32, ParameterDirection.Input);
                var res = await conn.QueryFirstOrDefaultAsync<GetModel>(GET_PROCEDURE, dParams, null, null, CommandType.StoredProcedure);
                return res;
            }
        }
        public async Task<IEnumerable<GetModel>> GetAllMethod()
        {
            using (var conn = _dbContext.CreateConnection())
            {
                DynamicParameters dParams = new DynamicParameters();
                var res = await conn.QueryAsync<GetModel>(GET_ALL_PROCEDURE, dParams, null, null, CommandType.StoredProcedure);
                return res.ToList();
            }
        }
      public async Task<int> SaveMethod(SaveModel data)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.Add("@temp", booking.temp);
                var res = await conn.ExecuteScalarAsync<int>(SAVE_PROCEDURE, dbParams, null, null, CommandType.StoredProcedure);
                return res;
               
            }
        }
      public async Task<int> UpdateMethod(SaveModel data)
        {
           using (var conn = _dbContext.CreateConnection())
            {
              DynamicParameters dbParams = new DynamicParameters();
              dbParams.Add("@temp", booking.temp);
              var res = await conn.ExecuteScalarAsync<int>(UPDATE_PROCEDURE, dbParams, null, null, CommandType.StoredProcedure);
              return res;
            }
        }
       public async Task<int> DeleteMethod(int Id)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.Add("Id", Id);
                var res = await conn.ExecuteScalarAsync<int>(DELETE_PROCEDURE, dbParams, null, null, CommandType.StoredProcedure);
                return res;
            }
        }
        #region PROCEDURES
        const string SAVE_PROCEDURE = "";
        const string GET_PROCEDURE = "";
        const string GET_ALL_PROCEDURE = "";
        const string DELETE_PROCEDURE = "";
        #endregion
    }
}
