using BlipApiTeste.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlipApiTeste.Services
{
    public class RepositoriesService
    {

        public async Task<List<Repositories>> GetAllRepositoriesAsync()
        {
            try
            {
                List<Repositories> repoCollection = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.urlGit);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.mediaType));
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(Constants.productName, Constants.productVersion));

                    var response = await client.GetAsync(Constants.reposAddress);

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync();
                        repoCollection = JsonConvert.DeserializeObject<List<Repositories>>(data.Result);
                    }
                }

                return repoCollection;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string RepositoriesFilteredByLanguage(string language, int quantity)
        {
            try
            {
                var filteredRepositories = GetAllRepositoriesAsync().Result.FindAll(x => x.Language == language).OrderBy(x => x.Created_At).ToList();

                List<Repositories> repos = new List<Repositories>();

                for (int i = 0; i < quantity; i++)
                {
                    repos.Add(filteredRepositories[i]);
                }

                string jsonRepos;


                using (HttpClient client = new HttpClient())
                {
                    jsonRepos = JsonConvert.SerializeObject(repos);

                }

                jsonRepos = jsonRepos.ToLower().Replace(@"\", "-");

                return jsonRepos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}