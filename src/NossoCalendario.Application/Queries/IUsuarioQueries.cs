using NossoCalendario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NossoCalendario.Application.Queries
{
    public interface IUsuarioQueries
    {
        Task<UsuarioViewModel> AutenticarUsuario(UsuarioLoginViewModel login);
    }
}
