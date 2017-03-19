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
    public partial class KategoriEditPage : ContentPage
    {
        public KategoriEditPage()
        {
            InitializeComponent();
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            KategoriServices kategoriService = new KategoriServices();
            Kategori editKategori = new Kategori
            {
                KategoriID = Convert.ToInt32(txtKategoriID.Text),
                KategoriNama = txtKategoriName.Text
            };

            try
            {
                await kategoriService.EditKategori(editKategori);
                //await DisplayAlert("Keterangan", "Data " + txtKategoriName.Text + " berhasil diupdate !", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            KategoriServices kategoriServices = new KategoriServices();
            var result = await DisplayAlert("Keterangan", "Apakah anda yakin untuk delete data " + txtKategoriName.Text + " ?", "OK", "Cancel");
            if (result)
            {
                try
                {
                    await kategoriServices.DeleteKategori(Convert.ToInt32(txtKategoriID.Text));
                    await DisplayAlert("Keterangan", "Data kategori " + txtKategoriName.Text + " berhasil didelete","OK");
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
