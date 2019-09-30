

namespace BDPrueba.Service
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Threading.Tasks;
    using BDPrueba.Model;
    using SQLite;
    public class Service<T> : IService<T> where T : class, new()
    {
        #region Atributos
        SQLiteAsyncConnection _conexion;
        #endregion

        #region Propiedades

        #endregion

        #region Constructor
        public Service()
        {
            Conexion();
        }
        #endregion

        #region metodos

        private void Conexion()
        {
            string path= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string file = "db_Tienda.db3";
            string FilePath = Path.Combine(path,file);

            _conexion = new SQLiteAsyncConnection(FilePath);
            _conexion.CreateTableAsync<Tbl_Producto>().Wait();

        }
        public Task<List<T>> All()
        {
            return _conexion.Table<T>().ToListAsync();
        }

        public Task<int> Delete(T obj)
        {
            return _conexion.DeleteAsync(obj);
        }

        public Task<int> Insert(T obj)
        {
            return _conexion.InsertAsync(obj);
        }

        public Task<int> Update(T obj)
        {
            return _conexion.UpdateAsync(obj);
        }

        public Task<ObservableCollection<T>> Alls()
        {
            throw new NotImplementedException();

        }

        #endregion

        #region Command

        #endregion

    }
}
