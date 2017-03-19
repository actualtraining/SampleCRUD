using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SampleCRUD.Model;
using SampleCRUD.Services;

namespace SampleCRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KategoriPage : ContentPage
    {
        private KategoriServices kategoriService;
        public KategoriPage()
        {
            InitializeComponent();
            kategoriService = new KategoriServices();

            listView.ItemSelected += ListView_ItemSelected;
            toolBarAdd.Clicked += ToolBarAdd_Clicked;
        }

        private async void ToolBarAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KategoriAddPage());
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var kategoriItem = e.SelectedItem as Kategori;
            //await DisplayAlert("Keterangan", kategoriItem.KategoriNama,"OK");
            KategoriEditPage kategoriEditPage = new KategoriEditPage();
            kategoriEditPage.BindingContext = kategoriItem;
            await Navigation.PushAsync(kategoriEditPage);
        }

        protected async override void OnAppearing()
        {
            myIndicator.IsVisible = true;
            myIndicator.IsRunning = true;

            base.OnAppearing();

            try
            {
                listView.ItemsSource = await kategoriService.GetAllKategori();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message,"OK");
            }
            

            myIndicator.IsRunning = false;
            myIndicator.IsVisible = false;
        }
    }
}
