

namespace Enviroment.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string ZipCode { get; set; } = String.Empty;
        public string Neigborhood { get; set; } = String.Empty;

        public string Street { get; set; } = String.Empty;

        public string Complement { get; set; } = String.Empty;
        public int Number { get; set; }
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = string.Empty;

    }
}
