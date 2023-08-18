using Enviroment.Application.Command.LicenseCommand;
using Enviroment.Application.Mapper;
using Enviroment.Application.Response.LicenseResponse;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Command;
using MediatR;


namespace Enviroment.Application.Handlers.CommandHandlers
{
    public class CreateLicenseHandler : IRequestHandler<CreateLicenseCommand, LicenseResponse>
    {
        private readonly ILinceseCommandRepository _linceseCommandRepository;

        public CreateLicenseHandler(ILinceseCommandRepository linceseCommandRepository)
        {
            _linceseCommandRepository = linceseCommandRepository;
        }

        public async Task<LicenseResponse> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
        {
            var licenseEntity = LicenseMapper.Mapper.Map<Licenses>(request);

            if (licenseEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newLicense = await _linceseCommandRepository.AddAsync(licenseEntity);
            var licenseResponse = LicenseMapper.Mapper.Map<LicenseResponse>(newLicense);

            return licenseResponse;
        }
    }
}
