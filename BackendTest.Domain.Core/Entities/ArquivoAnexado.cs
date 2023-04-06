﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Domain.Core.Entities
{
    public class ArquivoAnexado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}
