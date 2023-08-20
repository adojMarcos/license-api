using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Application.Command.ClientCommand
{
    public class DeleteClientCommand : IRequest<string>
    {
        public int Id { get; set; }

        public DeleteClientCommand(int id)
        {
            Id = id;
        }
    }
}
