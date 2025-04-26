using template_dotnet.Models;

namespace template_dotnet.Services
{
    public interface IExampleService
    {
        Task<ExampleModel?> getExample(int id);
        Task<IEnumerable<ExampleModel>> getExamples();
        Task<ExampleModel> postExamples(ExampleModel exampleModel);
        Task<ExampleModel> updateExample(ExampleModel exampleModel);
        Task deleteExample(int id);

    }
}
