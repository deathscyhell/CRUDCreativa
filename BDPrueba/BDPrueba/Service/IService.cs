


namespace BDPrueba.Service
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    public interface IService<T> where T : class, new()
    {
        Task<int> Insert(T obj);
        Task<int> Update(T obj);
        Task<int> Delete(T obj);

        Task<List<T>> All();

        Task<ObservableCollection<T>> Alls();


    }
}
