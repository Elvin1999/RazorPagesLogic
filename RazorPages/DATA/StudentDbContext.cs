using Microsoft.EntityFrameworkCore;
using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.DATA
{
    public class StudentDbContext :DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
           : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
