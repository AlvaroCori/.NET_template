using template_dotnet.Models;
using template_dotnet.Repository;

namespace template_dotnet.Services
{
    public class SSExampleService: ISSExampleService
    {
        private IDboRepository<SSExampleModel> repository { get; set; }
        public SSExampleService(IDboRepository<SSExampleModel> _repository)
        {
            repository = _repository;
        }
        async public Task DeleteSSExample(int id)
        {
            var example = await GetSSExample(id);
            if (example != null)
            {
                await repository.DeleteAsync(example);
            }
        }

        public async Task<SSExampleModel?> GetSSExample(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SSExampleModel>> GetSSExamples()
        {
            return await repository.GetAllAsync();
        }

        public async Task<SSExampleModel> PostSSExamples(SSExampleModel sSExampleModel)
        {
            await repository.AddAsync(sSExampleModel);
            return sSExampleModel;
        }

        public async Task<SSExampleModel> UpdateSSExample(SSExampleModel sSExampleModel)
        {
            return await repository.UpdateAsync(sSExampleModel);
        }
    }
}
