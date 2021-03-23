using App.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : EntidadeBase
    {
        Task Adicionar(TEntidade entidade);
        Task<TEntidade> ObterPorId(Guid Id);
        Task<List<TEntidade>> ObterTodos();
        Task Atualizar(TEntidade entidade);
        Task Remover(Guid Id);
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate);
        Task<int> SaveChanges();
    }
}
