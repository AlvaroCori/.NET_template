using Microsoft.EntityFrameworkCore;
using template_dotnet.Models;
using template_dotnet.Repository;

namespace template_dotnet.Services
{
    public class ExampleService : IExampleService
    {
        private IDboRepository<ExampleModel> repository { get; set; }
        public ExampleService(IDboRepository<ExampleModel> _repository) { 
            repository = _repository;
        }
        async public Task deleteExample(int id)
        {
            var example = await getExample(id);
            if (example != null)
            {
                await repository.Delete(example);
            }
        }

        public async Task<ExampleModel?> getExample(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ExampleModel>> getExamples()
        {
            return await repository.GetAllAsync();
        }

        public async Task<ExampleModel> postExamples(ExampleModel exampleModel)
        {
            await repository.AddAsync(exampleModel);
            return exampleModel;
        }

        public async Task<ExampleModel> updateExample(ExampleModel exampleModel)
        {
           return await repository.Update(exampleModel);
        }
    }
}
