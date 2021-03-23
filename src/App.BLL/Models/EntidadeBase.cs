using System;
using System.Collections.Generic;
using System.Text;

namespace App.BLL.Models
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
