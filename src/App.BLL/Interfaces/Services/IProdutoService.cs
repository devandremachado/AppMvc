using App.BLL.Models;
using System;
using System.Threading.Tasks;

namespace App.BLL.Interfaces.Services
{
    public interface IProdutoService: IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
