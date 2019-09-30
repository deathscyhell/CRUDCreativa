using BDPrueba.Model;
using BDPrueba.Service;
using BDPrueba.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDPrueba.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List_ProductPage : ContentPage
    {
        public List_ProductPage()
        {
            InitializeComponent();
            
        }



        private async void UserListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new Editar_ProductoPage()
            {
                BindingContext = new ProductoViewModel((Tbl_Producto)e.SelectedItem)
            });
        }
    }
}