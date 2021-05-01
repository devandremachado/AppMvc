using App.BLL.Models;
using System;
using System.Threading.Tasks;

namespace App.BLL.Interfaces.Repositories
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
