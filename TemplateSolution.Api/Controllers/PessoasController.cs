using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateSolution.Application.Interfaces;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Filters;

namespace TemplateSolution.Api.Controllers
{
    public class PessoasController : ApiController
    {
        private readonly IPessoas_AppService _pessoas_AppService;
        public PessoasController(IPessoas_AppService Pessoas_AppService)
        {
            _pessoas_AppService = Pessoas_AppService;
        }

        [Route("api/Pessoas")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] Pessoas_Filter filter)
        { 
            return CustomResponse(await _pessoas_AppService.GetDataListCustom(filter));
        }

        [Route("api/Pessoas/GetDetails")]
        [HttpGet()]
        public async Task<IActionResult> GetDetails(int id)
        { 
            return CustomResponse(await _pessoas_AppService.GetById(id));
        }

       
        [Route("api/Pessoas")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Pessoas_ViewModel viewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse((await _pessoas_AppService.Register(viewModel)));
        }

        [Route("api/Pessoas")]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Pessoas_ViewModel viewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _pessoas_AppService.Update(viewModel));
        }

        [Route("api/Pessoas")]
        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _pessoas_AppService.Remove(id));
        }

    }
}
