using AutoMapper;
using BackendTest.Application.Models.Tarefas;
using BackendTest.Application.Models.Usuarios;
using BackendTest.Application.Service.Interfaces.Tarefas;
using BackendTest.Application.Service.Interfaces.Usuarios;
using BackendTest.Application.Validator.Interfaces.Tarefas;
using BackendTest.Domain.Core.Entities;
using BackendTest.Domain.Database.Interfaces.IRepositories;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BackendTest.Application.Service.Tarefas
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITarefaValidator _tarefaValidator;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private const string _diretorioArquivos = @"C:\Arquivos\";

        public TarefaService(ITarefaRepository tarefaRepository, ITarefaValidator tarefaValidator, IUsuarioRepository usuarioRepository, IUsuarioService usuarioService, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _tarefaValidator = tarefaValidator;
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<TarefaResponse> Create(TarefaRequest tarefaRequest)
        {
            _tarefaValidator.CreateValidation(tarefaRequest);
            var tarefa = _mapper.Map<Tarefa>(tarefaRequest);

            _tarefaRepository.Insert(tarefa);
            var response = _mapper.Map<TarefaResponse>(tarefa);
            var usuario = _usuarioRepository.Select(tarefa.UsuarioId);
            response.Usuario = usuario;

            return response;
        }

        public async Task<TarefaResponse> Find(int id)
        {
            var tarefa = await _tarefaRepository.GetById(id);
            _tarefaValidator.FindValidation(tarefa);
            return _mapper.Map<TarefaResponse>(tarefa);
        }

        public async Task<TimeSpan> FindProgress(int id)
        {
            var tarefa = await _tarefaRepository.GetById(id);
            _tarefaValidator.FindValidation(tarefa);
            _tarefaValidator.FindProgressValidation(tarefa);
            if(tarefa.Status == Domain.Core.Enumerables.StatusTarefa.EmProgresso) 
            { 
                return DateTime.Now - tarefa.DataInicio;
            }
            else
            {
                return (TimeSpan)(tarefa.DataFim - tarefa.DataInicio);
            }
        }
        public async Task<TarefaResponse> Edit(int id, TarefaRequest tarefaRequest)
        {
            var tarefa = _tarefaRepository.Select(id);
            _tarefaValidator.FindValidation(tarefa);
            _tarefaValidator.EditValidation(tarefaRequest);

            tarefa.Status = tarefaRequest.Status;
            tarefa.Descricao = tarefaRequest.Descricao;
            tarefa.UsuarioId = tarefaRequest.UsuarioId;
            tarefa.DataFim = tarefaRequest.DataFim;
            tarefa.DataInicio = tarefaRequest.DataInicio;

            _tarefaRepository.Update(tarefa);
            return _mapper.Map<TarefaResponse>(tarefa);
        }

        #region Metodos desafio

        public async Task<TarefaResponse> CreateJoaoSilva()
        {
            var usuarioRequest = new UsuarioRequest
            {
                Name = "João Silva",
                Email = "joaosilva@email"
            };
            var usuario = await _usuarioService.Create(usuarioRequest);
            var tarefaRequest = new TarefaRequest
            {
                Descricao = "Tarefa do joao",
                DataInicio = DateTime.ParseExact("31/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Status = Domain.Core.Enumerables.StatusTarefa.Agendada,
                UsuarioId = usuario.Id
            };

            var response = await Create(tarefaRequest);

            return response;
        }

        public async Task<TarefaResponse> CreateAnaSilva()
        {
            var usuarioRequest = new UsuarioRequest
            {
                Name = "Ana Silva",
                Email = "anasilva@email"
            };
            var usuario = await _usuarioService.Create(usuarioRequest);
            var tarefaRequest = new TarefaRequest
            {
                Descricao = "Tarefa da Ana",
                DataInicio = DateTime.Today,
                Status = Domain.Core.Enumerables.StatusTarefa.Agendada,
                UsuarioId = usuario.Id
            };

            var response = await Create(tarefaRequest);

            return response;
        }

        public async Task<TarefaResponse> EditAna()
        {
            var tarefa = await _tarefaRepository.GetByUserName("Ana Silva");

            var tarefaRequest = new TarefaRequest
            {
                Status = Domain.Core.Enumerables.StatusTarefa.EmProgresso,
                DataFim = tarefa.DataFim,
                DataInicio = tarefa.DataInicio,
                Descricao = tarefa.Descricao,
                UsuarioId = tarefa.UsuarioId,
            };

            var response = await Edit(tarefa.Id,tarefaRequest);

            return response;
        }

        public async Task AnexarArquivo(int tarefaId, IFormFile arquivo)
        {
            var tarefa = _tarefaRepository.Select(tarefaId);
            _tarefaValidator.FindValidation(tarefa);
            _tarefaValidator.FileValidation(arquivo);

            var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(arquivo.FileName);

            var caminhoCompleto = Path.Combine(_diretorioArquivos, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            var arquivoAnexado = new ArquivoAnexado
            {
                Nome = nomeArquivo,
                Caminho = caminhoCompleto
            };

            tarefa.ArquivosAnexados.Add(arquivoAnexado);

            _tarefaRepository.Update(tarefa);
        }
        #endregion
    }
}
