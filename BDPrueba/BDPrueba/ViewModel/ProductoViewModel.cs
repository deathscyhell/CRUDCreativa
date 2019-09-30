using BDPrueba.Model;
using BDPrueba.Service;
using BDPrueba.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BDPrueba.ViewModel
{
    public class ProductoViewModel :BaseViewModel
    {
        #region Atributos
        private Tbl_Producto _producto;
        private List<Tbl_Producto> listProduct;
         
        private string nombre;
        private double precio;
        private DateTime fecha;
        private DateTime hora;

        
        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return nombre; }
            set { SetValue(ref nombre, value);}
        }
        public double Precio
        {
            get { return precio; }
            set { SetValue(ref precio, value); }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { SetValue(ref fecha , value); }
        }
        public DateTime Hora
        {
            get { return hora; }
            set { SetValue(ref hora ,value); }
        }

        //public Tbl_Producto _producto
        //{
        //    get { return _Producto; }
        //    set
        //    {
        //        if (_Producto != null)
        //        {
        //            _Producto = value;
        //            SelectUser(_producto);
        //            _Producto = null;
        //        };
                
        //    }
        //}



        // public List<Tbl_Producto> ListProducto { get; set; } = new List<Tbl_Producto>();


        public List<Tbl_Producto> ListProducto
        {
            get { return listProduct; }
            set { SetValue(ref listProduct,value);
                OnPropertyChanged("ListProducto");
            }
        }

        #endregion

        #region Constructor
        public ProductoViewModel(Tbl_Producto productos) : this()
        {

            this._producto = productos;
            if (productos != null)
            {
                Nombre = productos.Nombre_Producto;
                Precio = productos.Precio;
                Fecha = productos.Fecha_ingreso;
                Hora = productos.Hora_ingreso;
            }
        }
        public ProductoViewModel()
        {
            var hora_actual = DateTime.Now.ToString("MM/dd/yyyy");
            Hora = Convert.ToDateTime(hora_actual);
            var fecha_actual = DateTime.Now.ToString("h:mm tt");
            Fecha = Convert.ToDateTime(fecha_actual);

            GetUser();
            
            GuardarCommand = new Command(Guardar);
            EditarCommand = new Command(Editar);
            EliminarCommand = new Command(Eliminar);
            CancelarCommand = new Command(async()=>
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                });
            AgregarCommand = new Command
                (async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Add_ProductoPage());
                });

            
        }
        #endregion

        #region metodos
        public async void GetUser()
        {
            var _service = new Service<Tbl_Producto>();
            ListProducto = await _service.All();

        }
        //public async void SelectUser(Tbl_Producto productos)
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new Editar_ProductoPage()
        //    {
           
            
        //    });
            
           

        //}
        private async void Guardar(object obj)
        {
            var servi = new Service<Tbl_Producto>();
            var _producto = new Tbl_Producto();
            _producto.Nombre_Producto = Nombre;
            _producto.Precio = Precio;
            _producto.Fecha_ingreso = Fecha;
            _producto.Hora_ingreso = Hora;

            var resultado = await servi.Insert(_producto);
            if (resultado == 1)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de Aviso",
                    "Registro Guardado", "Aceptar");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de aviso"," Error Al Guardar Revise los datos","Aceptar");
            }
        }

        private async void Editar(object obj)
        {
            if (_producto != null)
            {
                _producto.Nombre_Producto = nombre;
                _producto.Precio = precio;
                _producto.Fecha_ingreso = Fecha;
                _producto.Hora_ingreso = Hora;


                var Servi = new Service<Tbl_Producto>();
                var result = await Servi.Update(_producto);
                if (result == 1)
                {
                    await App.Current.MainPage.DisplayAlert("Mensaje de aviso", "Registro Actualizado con exito!!!", "Aceptar");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        private async void Eliminar(object obj)
        {
            var Servi = new Service<Tbl_Producto>();
            var result = await Servi.Delete(_producto);
            if (result == 1)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de aviso", "Registro Eliminado con exito!!!", "Aceptar");
                await App.Current.MainPage.Navigation.PopAsync();

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de aviso", "Error al Eliminar", "Acepatr");
            }
        }
        #endregion

        #region Command
        public Command AgregarCommand { get; set; }
        public Command GuardarCommand { get; set; }
        public Command EditarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command CancelarCommand { get; set; }
        #endregion
    }
}
