
namespace template_dotnet.DTO
{
    public class SSExampleDTO
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required DateTime RegisterDate { get; set; }
        public required char State { get; set; }

        public ICollection<SSRExampleDTO> Ubications { get; set; } = new List<SSRExampleDTO>();

    }
}
