using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateSolution.Application.Interfaces;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Filters;

namespace TemplateSolution.Api.Controllers
{
    public class ContatosController : ApiController
    {
        private readonly IContatos_AppService _contatos_AppService;
        public ContatosController(IContatos_AppService Contatos_AppService)
        {
            _contatos_AppService = Contatos_AppService;
        }

        [Route("api/Contatos")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] Contatos_Filter filter)
        {
            return CustomResponse(await _contatos_AppService.GetDataListCustom(filter));
            
        }

        [Route("api/Contatos/GetDetails")]
        [HttpGet()]
        public async Task<IActionResult> GetDetails(int id)
        {
            return CustomResponse(await _contatos_AppService.GetById(id));
        }

        [Route("api/Contatos")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Contatos_ViewModel viewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse((await _contatos_AppService.Register(viewModel)));
           
        }

        [Route("api/Contatos")]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Contatos_ViewModel viewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _contatos_AppService.Update(viewModel));
            
        }

        [Route("api/Contatos")]
        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _contatos_AppService.Remove(id));
          
        }

    }
}
