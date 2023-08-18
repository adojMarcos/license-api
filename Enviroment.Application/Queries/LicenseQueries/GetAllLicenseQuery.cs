using Enviroment.Core.Entities;
using MediatR;

namespace Enviroment.Application.Queries.LicenseQueries
{
    public class GetAllLicenseQuery : IRequest<List<Licenses>>
    {
    }
}
