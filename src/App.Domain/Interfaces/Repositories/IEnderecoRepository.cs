using App.Domain.Models;
using System;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
