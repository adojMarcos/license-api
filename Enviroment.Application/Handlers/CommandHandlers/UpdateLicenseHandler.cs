using Enviroment.Application.Command.LicenseCommand;
using Enviroment.Application.Mapper;
using Enviroment.Application.Response.LicenseResponse;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Command;
using Enviroment.Core.Repositories.Query;
using MediatR;


namespace Enviroment.Application.Handlers.CommandHandlers
{
    public class UpdateLicenseHandler : IRequestHandler<UpdateLicenseCommand, LicenseResponse>
    {
        private readonly ILinceseCommandRepository _linceseCommandRepository;
        private readonly ILicenseQueryRepository _licenseQueryRepository;

        public UpdateLicenseHandler(ILinceseCommandRepository linceseCommandRepository, ILicenseQueryRepository licenseQueryRepository)
        {
            _linceseCommandRepository = linceseCommandRepository;
            _licenseQueryRepository = licenseQueryRepository;
        }

        public async Task<LicenseResponse> Handle(UpdateLicenseCommand request, CancellationToken cancellationToken)
        {
            var licenseEntity = LicenseMapper.Mapper.Map<Licenses>(request);
            if (licenseEntity == null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _linceseCommandRepository.UpdateAsync(licenseEntity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            var modifiedLicense = await _licenseQueryRepository.GetByIdAsync(request.Id);
            var licenseResponse = LicenseMapper.Mapper.Map<LicenseResponse>(modifiedLicense);

            return licenseResponse;
        }

    }
}
