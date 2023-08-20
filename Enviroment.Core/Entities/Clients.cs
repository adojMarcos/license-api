using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Core.Entities
{
    public class Clients
    {
        public int Id { get; set; }
        public string CorporateName { get; set; } = String.Empty;
        public string TradeName { get; set; } = String.Empty;
        public string Responsible { get; set; } = String.Empty;
        public string Cellphone { get;  set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Rg { get; set; } = String.Empty;
        public string CNPJ { get; set; } = String.Empty;
        public bool IsClient { get; set; } 

        public Address Address { get; set; }


        public Clients()
        {
            Address = new Address();
        }
    }
}
