using Enviroment.Application.Response.ClientResponse;
using MediatR;

namespace Enviroment.Application.Command.ClientCommand
{
    public class UpdateClientCommand : IRequest<ClientResponse>
    {
        public int Id { get; set; }
        public string CorporateName { get; set; } = String.Empty;
        public string TradeName { get; set; } = String.Empty;
        public string Responsible { get; set; } = String.Empty;
        public string Cellphone { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Rg { get; set; } = String.Empty;
        public string CNPJ { get; set; } = String.Empty;
        public string ZipCode { get; set; } = String.Empty;
        public string Neigborhood { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public string Complement { get; set; } = String.Empty;
        public int Number { get; set; }
        public string City { get; set; } = String.Empty;
        public int State { get; set; }
    }
}
