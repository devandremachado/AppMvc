using App.Domain.Models;
using System;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Services
{
    public interface IProdutoService: IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
