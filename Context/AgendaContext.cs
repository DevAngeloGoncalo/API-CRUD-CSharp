using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModuloAPI.Entities;

namespace ModuloAPI.Context
{
    //Classe que acessa o banco de dados
    public class AgendaContext : DbContext
    {
        //Conexão com banco de dados
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }    

        //Verifica o registro do banco de dados
        //Se a classe não estiver aqui, ela não vai ser identificada como tabela
        public DbSet<Contato> Contatos { get; set; }
    }
}