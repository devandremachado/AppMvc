using App.Domain.Interfaces.Repositories;
using App.Domain.Models;
using App.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace App.Infra.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }

    }
}
