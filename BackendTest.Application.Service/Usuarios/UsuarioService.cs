using AutoMapper;
using BackendTest.Application.Models.Usuarios;
using BackendTest.Application.Service.Interfaces.Usuarios;
using BackendTest.Application.Validator.Interfaces.Usuarios;
using BackendTest.Domain.Core.Entities;
using BackendTest.Domain.Database.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Application.Service.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioValidator _usuarioValidator;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUsuarioValidator usuarioValidator, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioValidator = usuarioValidator;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> Create(UsuarioRequest usuarioRequest)
        {
            var client = _mapper.Map<Usuario>(usuarioRequest);

            _usuarioRepository.Insert(client);
            return _mapper.Map<UsuarioResponse>(client);
        }
    }
}
