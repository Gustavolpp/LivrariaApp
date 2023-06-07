using LivrariaApp.Domain.Models.Seed;

namespace LivrariaApp.Domain.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
