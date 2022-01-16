namespace BlipApiTeste.Models
{
    public class Repositories
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Created_At { get; set; }

        public Repositories(string name, string language, string description, string created_At)
        {
            Name = name;
            Language = language;
            Description = description;
            Created_At = created_At;
        }
    }
}