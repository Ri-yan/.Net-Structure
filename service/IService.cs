namespace Project.Service
{
    public interface IService
    {
        Task<int> SaveMethod(SaveModel incident);
        Task<int> UpdateUpdate(UpdateModel incident);
        Task<IEnumerable<GetModel>> GetAllMethod();
        Task<GetModel> GetMethod(int Id);
        Task<int> DeleteMethod(int Id);
    }
}
