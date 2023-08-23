using MediatR;

namespace Enviroment.Application.Command.LicenseCommand
{
    public class DeleteLicenseCommand : IRequest<string>
    {
        public int Id { get; set; }

        public DeleteLicenseCommand(int id)
        {
            Id = id;
        }
    }
}
