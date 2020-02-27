using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models.Database
{
    public interface IModelCreatingDbContextEnhancer
    {
        void OnModelCreating(ModelBuilder builder);
    }
}
