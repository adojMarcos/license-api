using Enviroment.Application.Command.LicenseCommand;
using Enviroment.Core.Repositories.Command;
using Enviroment.Core.Repositories.Query;
using MediatR;

namespace Enviroment.Application.Handlers.CommandHandlers
{
    public class DeleteLicenseHandler : IRequestHandler<DeleteLicenseCommand, string>
    {
        private readonly ILinceseCommandRepository _linceseCommandRepository;
        private readonly ILicenseQueryRepository _licenseQueryRepository;

        public DeleteLicenseHandler(ILinceseCommandRepository linceseCommandRepository, ILicenseQueryRepository licenseQueryRepository)
        {
            _linceseCommandRepository = linceseCommandRepository;
            _licenseQueryRepository = licenseQueryRepository;
        }

        public async Task<string> Handle(DeleteLicenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var licenseId = await _licenseQueryRepository.GetByIdAsync(request.Id);

                await _linceseCommandRepository.DeleteAsync(licenseId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return "License deleted!";
        }

    }
}
