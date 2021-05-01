using App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public class Fornecedor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public ETipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
