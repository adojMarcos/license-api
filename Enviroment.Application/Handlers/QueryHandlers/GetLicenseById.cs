using Enviroment.Application.Queries.LicenseQueries;
using Enviroment.Core.Entities;
using MediatR;

namespace Enviroment.Application.Handlers.QueryHandlers
{
    public class GetLicenseById : IRequestHandler<GetLicenseByIdQuery, Licenses>
    {
        private readonly IMediator _mediator;

        public GetLicenseById(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Licenses> Handle(GetLicenseByIdQuery request, CancellationToken cancellationToken)
        {
            var licenses = await _mediator.Send(new GetAllLicenseQuery());
            var selectedLicense = licenses.FirstOrDefault(x => x.Id == request.Id);
            return selectedLicense;
        }
    }
}
