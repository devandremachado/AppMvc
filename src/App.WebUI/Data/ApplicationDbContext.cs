using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.WebUI.ViewModels;

namespace App.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<App.WebUI.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }
        public DbSet<App.WebUI.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
    }
}
