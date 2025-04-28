using Microsoft.AspNetCore.Mvc;
using template_dotnet.Models;
using template_dotnet.Services;


namespace template_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SSExampleController : ControllerBase
    {
        private ISSExampleService service;
        public SSExampleController(ISSExampleService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<IEnumerable<SSExampleModel>> Get()
        {
            return await service.GetSSExamples();
        }
        [HttpGet("{id}")]
        public async Task<SSExampleModel?> GetOne(int id)
        {
            return await service.GetSSExample(id);
        }
        [HttpPost]
        public async Task<SSExampleModel?> Post(SSExampleModel example)
        {
            return await service.PostSSExamples(example);
        }
        [HttpPut("{id}")]
        public async Task<SSExampleModel?> Update(int id, SSExampleModel example)
        {
            example.Id = id;
            return await service.UpdateSSExample(example);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteSSExample(id);
        }
    }
}
