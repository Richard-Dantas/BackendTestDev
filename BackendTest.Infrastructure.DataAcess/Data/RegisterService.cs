using AutoMapper;
using BackendTest.Application.Models.Tarefas;
using BackendTest.Application.Models.Usuarios;
using BackendTest.Domain.Core.Entities;

namespace BackendTest.Infrastructure.DataAcess.Data
{
    public class RegisterService : Profile
    {
        public RegisterService()
        {
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<Tarefa, TarefaResponse>();



            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<TarefaRequest, Tarefa>();
        }
    }
}
