﻿using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);

    }
}
