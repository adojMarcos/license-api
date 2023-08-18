using MediatR;

namespace Enviroment.Application.Command.LicenseCommand
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
