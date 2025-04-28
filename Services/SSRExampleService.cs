using template_dotnet.DTO;
using template_dotnet.Models;
using template_dotnet.Repository;

namespace template_dotnet.Services
{
    public class SSRExampleService : ISSRExampleService
    {
        private IDboRepository<SSRExampleModel> repository { get; set; }
        public SSRExampleService(IDboRepository<SSRExampleModel> _repository)
        {
            repository = _repository;
        }
        public async Task DeleteSSRExample(int id)
        {
            var example = await GetSSRExample(id);
            if (example != null)
            {
                await repository.DeleteAsync(example);
            }
        }

        public async Task<SSRExampleModel?> GetSSRExample(int id)
        {
            return await repository.GetByIdAsync(id, includes: x => x.UbicationModel);
        }

        public async Task<IEnumerable<SSRExampleModel>> GetSSRExamples()
        {
            return await repository.GetAllAsync(includes: x => x.UbicationModel);
        }

        public async Task<SSRExampleModel> PostSSRExamples(SSRExampleDTO sSRExample)
        {

            if (sSRExample == null)
            {
                throw new ArgumentNullException(nameof(sSRExample));
            }

            var sSRExampleModel = new SSRExampleModel
            {
                StateId = sSRExample.StateId,
                Ubication = sSRExample.Ubication,
                Province = sSRExample.Province,
                Municipe = sSRExample.Municipe,
                Comunity = sSRExample.Comunity,
                RegisterDate = DateTime.UtcNow,
                State = 'A'
            };
            await repository.AddAsync(sSRExampleModel);
            return sSRExampleModel;
        }

        public async Task<SSRExampleModel> UpdateSSRExample(int id, SSRExampleDTO sSRExample)
        {
            if (sSRExample == null)
                throw new ArgumentNullException(nameof(sSRExample));

            var existingModel = await repository.GetByIdAsync(id);
            if (existingModel == null)
                throw new KeyNotFoundException($"Registro con ID {id} no encontrado");

            existingModel.StateId = sSRExample.StateId;
            existingModel.Ubication = sSRExample.Ubication;
            existingModel.Province = sSRExample.Province;
            existingModel.Municipe = sSRExample.Municipe;
            existingModel.Comunity = sSRExample.Comunity;
            //existingModel.RegisterDate = DateTime.UtcNow;

            await repository.UpdateAsync(existingModel);
            await repository.SaveChangesAsync();

            return existingModel;
        }
    }
}
