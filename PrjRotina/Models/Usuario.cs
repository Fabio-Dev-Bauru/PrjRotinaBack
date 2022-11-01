using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjRotina.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
            Login = string.Empty;
            Senha = string.Empty;
        }

        public string Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
