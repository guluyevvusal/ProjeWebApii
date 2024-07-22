using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Domen.Entities;

namespace ProjeWebApii.APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;

        public ValuesController(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }


        [HttpGet]

        public async Task<IActionResult>  Get()
        {
            return Ok(await unitofWork.GetReadRepository<Product>().GetAllAsync());
        }
    }
}
