using Enviroment.Application.Command.ClientCommand;
using Enviroment.Application.Mapper;
using Enviroment.Application.Response.ClientResponse;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Command;
using Enviroment.Core.Repositories.Query;
using MediatR;

namespace Enviroment.Application.Handlers.CommandHandlers.ClientCommandHandlers
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, ClientResponse>
    {
        public readonly IClientCommandRepository _clientCommandRepository;
        public readonly IClientQueryRepository _clientQueryRepository;

        public UpdateClientHandler(IClientCommandRepository clientCommandRepository, IClientQueryRepository clientQueryRepository)
        {
            _clientCommandRepository = clientCommandRepository;
            _clientQueryRepository = clientQueryRepository;
        }
        public async Task<ClientResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientEntity = LicenseMapper.Mapper.Map<Clients>(request) ?? throw new ApplicationException("There is a problem in mapper");

            try
            {
                await _clientCommandRepository.UpdateAsync(clientEntity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            var modifiedClient = await _clientQueryRepository.GetByIdAsync(request.Id);
            var clientResponse = LicenseMapper.Mapper.Map<ClientResponse>(modifiedClient);

            return clientResponse;
        }
    }
}
