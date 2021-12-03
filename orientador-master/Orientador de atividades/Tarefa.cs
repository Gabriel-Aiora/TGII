using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orientador_de_atividades
{
    public class Tarefa
    {
        public Tarefa(string descricao, DateTime data)
        {
            Descricao = descricao;
            Data = data;
        }
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }

    public class OrientadorContext : DbContext 
    { 
        public DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=A2NWPLSK14SQL-v02.shr.prod.iad2.secureserver.net;Database=orientador;User Id=orientador;Password=Orientador@2021;");
        }
    }
}
