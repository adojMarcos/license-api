using Enviroment.Application.Command.ClientCommand;
using Enviroment.Core.Repositories.Command;
using Enviroment.Core.Repositories.Query;
using MediatR;

namespace Enviroment.Application.Handlers.CommandHandlers.ClientCommandHandlers
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, string>
    {
        public readonly IClientCommandRepository _clientCommandRepository;
        public readonly IClientQueryRepository _clientQueryRepository;

        public DeleteClientHandler(IClientCommandRepository clientCommandRepository, IClientQueryRepository clientQueryRepository)
        {
            _clientCommandRepository = clientCommandRepository;
            _clientQueryRepository = clientQueryRepository;
        }
        public async Task<string> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var licenseId = await _clientQueryRepository.GetByIdAsync(request.Id);

                await _clientCommandRepository.DeleteAsync(licenseId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return "Client deleted!";
        }
    }
}
