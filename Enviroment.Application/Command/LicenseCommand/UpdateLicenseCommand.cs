using Enviroment.Application.Response.LicenseResponse;
using MediatR;


namespace Enviroment.Application.Command.LicenseCommand
{
    public class UpdateLicenseCommand : IRequest<LicenseResponse>
    {
        public int Id { get; set; }
        public string LicenseName { get; set; } = "";
    }
}
