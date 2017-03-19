using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleCRUD.Model;
using SampleCRUD.Services;
using System.Diagnostics;

namespace SampleCRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KategoriAddPage : ContentPage
    {
        public KategoriAddPage()
        {
            InitializeComponent();
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            KategoriServices kategoriService = new KategoriServices();
            Kategori newKategori = new Kategori()
            {
                KategoriNama = txtKategoriName.Text
            };

            try
            {
                await kategoriService.TambahKategori(newKategori);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Keterangan", ex.Message,"OK");
            }
        }
    }
}
