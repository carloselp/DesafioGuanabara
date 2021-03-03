using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioGuanabara
{
    public abstract class TMDB
    {
        private Configuracao _config;
        private HttpClient _apiClient;

        public TMDB(Configuracao config)
        {
            _config = config;

            _apiClient = new HttpClient();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public abstract Task<string> RetornarDesafio(int idFilme);

        public async Task<Model.Movie> RetornarFilme(int id)
        {
            Model.Movie filme = new Model.Movie();

            string url = _config.BaseUrl + "movie/" + id + $"?api_key={_config.ApiKey}&language={_config.Language}";

            using (HttpResponseMessage response = await _apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Model.Movie>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
