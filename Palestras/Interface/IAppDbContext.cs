using Lecture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lectures.Interface
{
    public interface IAppDbContext
    {
        DbSet<Speakers> Speakers { get; set; }
        Task<int> SaveChangesAsync();
        void Add(Speakers speakers);
        void Update(Speakers speakers);
    }
}
