using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models.Data
{
    public class BlazorAppContext : DbContext
    {
        public BlazorAppContext( DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }


    }
}
