using Enviroment.Application.Queries.LicenseQueries;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using MediatR;

namespace Enviroment.Application.Handlers.QueryHandlers
{
    public class GetLicenseById : IRequestHandler<GetLicenseByIdQuery, Licenses>
    {
        private readonly ILicenseQueryRepository _licenseQueryRepository;


        public GetLicenseById(ILicenseQueryRepository licenseQueryRepository)
        {
            _licenseQueryRepository = licenseQueryRepository;
        }
        public async Task<Licenses> Handle(GetLicenseByIdQuery request, CancellationToken cancellationToken)
        {
            var selectedLicense = await _licenseQueryRepository.GetByIdAsync(request.Id);
            return selectedLicense;
        }
    }
}
