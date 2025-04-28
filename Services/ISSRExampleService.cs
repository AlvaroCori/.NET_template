using template_dotnet.DTO;
using template_dotnet.Models;

namespace template_dotnet.Services
{
    public interface ISSRExampleService
    {
        Task<SSRExampleModel?> GetSSRExample(int id);
        Task<IEnumerable<SSRExampleModel>> GetSSRExamples();
        Task<SSRExampleModel> PostSSRExamples(SSRExampleDTO sSRExample);
        Task<SSRExampleModel> UpdateSSRExample(int id, SSRExampleDTO sSRExample);
        Task DeleteSSRExample(int id);
    }
}
