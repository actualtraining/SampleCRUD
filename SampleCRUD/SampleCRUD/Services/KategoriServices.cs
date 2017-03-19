using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using SampleCRUD.Model;

namespace SampleCRUD.Services
{
    public class KategoriServices
    {
        private RestClient _client;

        public KategoriServices()
        {
            _client = new RestClient(Helpers.GetUrl());
        }

        public async Task<List<Kategori>> GetAllKategori()
        {
            var request = new RestRequest("api/Kategori", Method.GET);
            var response = await _client.Execute<List<Kategori>>(request);
            if (response.Data == null)
                throw new Exception("Status :" + response.StatusCode.ToString() + " " + response.StatusDescription);
            return response.Data;
        }

        public async Task TambahKategori(Kategori kategori)
        {
            var request = new RestRequest("api/Kategori", Method.POST);
            request.AddBody(kategori);
            try
            {
                await _client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception;
            }
        }
    }
}
