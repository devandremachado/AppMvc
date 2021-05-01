using App.BLL.Interfaces.Repositories;
using App.BLL.Models;
using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : EntidadeBase, new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntidade> DbSet;

        protected Repository(AppDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntidade>();
        }

        public async Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntidade> ObterPorId(Guid Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<List<TEntidade>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid Id)
        {
            DbSet.Remove(new TEntidade { Id = Id});
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
