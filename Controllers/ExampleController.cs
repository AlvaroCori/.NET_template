using Microsoft.AspNetCore.Mvc;
using template_dotnet.Models;
using template_dotnet.Services;

namespace template_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private IExampleService service;
        public ExampleController(IExampleService _service)
        {
            service = _service;
        }
        [HttpGet(Name = "/")]
        public async Task<IEnumerable<ExampleModel>> Get()
        {
            return await service.getExamples();
        }
        [HttpGet(Name = "/:id")]
        public async Task<ExampleModel?> GetOne(int id)
        {
            return await service.getExample(id);
        }
        [HttpGet(Name = "/post")]
        public async Task<ExampleModel?> Post(ExampleModel example)
        {
            return await service.postExamples(example);
        }
        [HttpGet(Name = "/update:id")]
        public async Task<ExampleModel?> Update(int id, ExampleModel example)
        {
            example.Id = id;
            return await service.updateExample(example);
        }
        [HttpGet(Name = "/delete:id")]
        public async Task Delete(int id)
        {
            await service.deleteExample(id);
        }
    }
}
