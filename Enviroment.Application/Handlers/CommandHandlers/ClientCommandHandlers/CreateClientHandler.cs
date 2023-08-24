using Enviroment.Application.Command.ClientCommand;
using Enviroment.Application.Mapper;
using Enviroment.Application.Response.ClientResponse;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Command;
using MediatR;

namespace Enviroment.Application.Handlers.CommandHandlers.ClientCommandHandlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientResponse>
    {
        IClientCommandRepository _commandRepository;

        public CreateClientHandler(IClientCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public async Task<ClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var clientEntity = LicenseMapper.Mapper.Map<Clients>(request) ?? throw new ApplicationException("There is a problem in mapper");
            var newClient = await _commandRepository.AddAsync(clientEntity);

            var i = LicenseMapper.Mapper.Map<ClientResponse>(newClient);

            return i;
        }
    }
}
