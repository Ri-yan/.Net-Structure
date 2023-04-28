namespace Project.Service
{
    public class Service : IService
    {
        private readonly IRepository _repo;
        public Service(IRepository repo)
        {
           _repo=repo;
        }
        public async Task<GetModel> GetMethod(int Id)
        {
            return await _repo.GetMethod(Id);
        }
        public async Task<IEnumerable<GetModel>> GetAllMethod()
        {
            return await _repo.GetAllMethod();
        }
      public async Task<int> SaveMethod(SaveModel data)
        {
            return await _repo.SaveMethod(data);
        }
      public async Task<int> UpdateMethod(SaveModel data)
        {
           return await _repo.UpdateMethod(data);
        }
       public async Task<int> DeleteMethod(int Id)
        {
           return await _repo.DeleteMethod(Id);
        }
    }
}
