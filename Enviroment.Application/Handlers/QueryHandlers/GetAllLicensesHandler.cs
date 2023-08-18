using Enviroment.Application.Queries.LicenseQueries;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using MediatR;


namespace Enviroment.Application.Handlers.QueryHandlers
{
    public class GetAllLicensesHandler : IRequestHandler<GetAllLicenseQuery, List<Licenses>>
    {
        private readonly ILicenseQueryRepository _licenseQueryRepository;

        public GetAllLicensesHandler(ILicenseQueryRepository licenseQueryRepository)
        {
            _licenseQueryRepository = licenseQueryRepository;
        }

        public async Task<List<Licenses>> Handle(GetAllLicenseQuery request, CancellationToken cancellationToken)
        {
            return (List<Licenses>)await _licenseQueryRepository.GetAllAsync();
        }
    }
}
