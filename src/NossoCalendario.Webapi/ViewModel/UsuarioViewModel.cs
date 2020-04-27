using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NossoCalendario.WebApi.ViewModel
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
