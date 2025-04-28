using template_dotnet.Models;

namespace template_dotnet.Services
{
    public interface ISSExampleService
    {
        Task<SSExampleModel?> GetSSExample(int id);
        Task<IEnumerable<SSExampleModel>> GetSSExamples();
        Task<SSExampleModel> PostSSExamples(SSExampleModel sSExampleModel);
        Task<SSExampleModel> UpdateSSExample(SSExampleModel sSExampleModel);
        Task DeleteSSExample(int id);
    }
}
