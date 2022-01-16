using BlipApiTeste;
using BlipApiTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers
{
    public class RepositoriesController : ControllerBase
    {

        private readonly RepositoriesService _repositoriesService;

        public RepositoriesController(RepositoriesService repositoriesService)
        {
            _repositoriesService = repositoriesService;
        }


        [HttpGet]
        [Route("api/getrepositories")]
        public string GetRepositories()
        {
            try
            {
                return _repositoriesService.RepositoriesFilteredByLanguage(Constants.language, Constants.reposQuantity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
