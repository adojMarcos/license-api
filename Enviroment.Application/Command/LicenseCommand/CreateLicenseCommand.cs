using Enviroment.Application.Response.LicenseResponse;
using MediatR;

namespace Enviroment.Application.Command.LicenseCommand
{
    public class CreateLicenseCommand : IRequest<LicenseResponse>
    {
        public string LicenseName { get; set; } = "";
    }
}
