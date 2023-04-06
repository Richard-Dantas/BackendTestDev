using BackendTest.Application.Models.Usuarios;

namespace BackendTest.Application.Service.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> Create(UsuarioRequest usuarioRequest);
    }
}
