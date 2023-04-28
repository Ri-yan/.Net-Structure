namespace Project.Repository
{
    public interface IRepository
    {
        Task<int> SaveMethod(SaveModel incident);
        Task<int> UpdateUpdate(UpdateModel incident);
        Task<IEnumerable<GetModel>> GetAllMethod();
        Task<GetModel> GetMethod(int Id);
        Task<int> DeleteMethod(int Id);
    }
}
