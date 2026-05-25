using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CopaHAS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Jogador> TB_JOGADORES { get; set; }      
        public DbSet<Estadio> TB_ESTADIO {get;set;}
        public DbSet<Selecao> TB_SELECOES {get;set;}
        public DbSet<Tecnico> TB_TECNICOS {get;set;}
        public DbSet<Jogo> TB_JOGOS {get;set;}
        public DbSet<JogoSelecao> TB_JOGO_SELECOES {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().ToTable("TB_JOGADORES");
            //JOGADOR (1:N com Selecao)
            modelBuilder.Entity<Jogador>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome)
                    //.HasColumnName("Nome da classe no banco")
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Posicao)
                    .HasMaxLength(50);
                //entity.Property(e => e.NumeroCamisa)
                    //.HasColumnName("Nome da coluna no banco)
                entity.HasOne(d => d.SelecaoIdNavegacao)
                    .WithMany(p => p.Jogadores)
                    .HasForeignKey(d => d.SelecaoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Estadio>().ToTable("TB_ESTADIO");
            //ESTADIO
            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.Cidade)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Selecao>().ToTable("TB_SELECOES");
            //SELECAO
            modelBuilder.Entity<Selecao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(100);
                
            });

            modelBuilder.Entity<Tecnico>().ToTable("TB_TECNICOS");
            //TECNICO (1:1 com Selecao)
            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasOne(d => d.SelecaoIdNavegacao)
                    .WithOne(p => p.Tecnico)
                    .HasForeignKey<Tecnico>(d => d.SelecaoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Jogo>().ToTable("TB_JOGOS");
            // JOGO (1:N com Estadio)
            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DataHora)
                    .IsRequired();
                //entity.Property(e => e.DataHora)
                    //.HasColumnName("Nome da coluna no banco");
                entity.HasOne(d => d.EstadioIdNavegacao)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.EstadioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<JogoSelecao>().ToTable("TB_JOGOS_SELECOES");
            //JOGO-SELEÇÕES (N:N)
            modelBuilder.Entity<JogoSelecao>(entity =>
            {
                entity.HasKey(e => new {e.JogoId, e.SelecaoId});
                entity.HasOne(d => d.JogoIdNavegacao)
                    .WithMany(p => p.JogoSelecoes)
                    .HasForeignKey(d => d.JogoId);

                entity.HasOne(d => d.SelecaoIdNavegacao)
                    .WithMany(p => p.JogoSelecoes)
                    .HasForeignKey(d => d.SelecaoId);
            });

            modelBuilder.Entity<Jogador>().HasData
            (
                new Jogador(){ Id=1, Nome="Hugo Souza",NumeroCamisa=1,Posicao="Goleiro",Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=2, Nome="Yuri Alberto",NumeroCamisa=9,Posicao="Atacante",Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=3, Nome="Danilo", NumeroCamisa=2, Posicao="Lateral Direito", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=4, Nome="Marquinhos", NumeroCamisa=4, Posicao="Zagueiro", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=5, Nome="Casemiro", NumeroCamisa=5, Posicao="Volante", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=6, Nome="Alex Sandro", NumeroCamisa=6, Posicao="Lateral Esquerdo", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=7, Nome="Lucas Paquetá", NumeroCamisa=7, Posicao="Meio Campo", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=8, Nome="Bruno Guimarães", NumeroCamisa=8, Posicao="Meio Campo", Status=Models.Enuns.StatusJogador.Reserva },
                new Jogador(){ Id=9, Nome="Richarlison", NumeroCamisa=10, Posicao="Atacante", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=10, Nome="Vinicius Jr", NumeroCamisa=11, Posicao="Atacante", Status=Models.Enuns.StatusJogador.Titular },
                new Jogador(){ Id=11, Nome="Rodrygo", NumeroCamisa=19, Posicao="Atacante", Status=Models.Enuns.StatusJogador.DepartamentoMedico },
                new Jogador(){ Id=12, Nome="Alisson", NumeroCamisa=23, Posicao="Goleiro", Status=Models.Enuns.StatusJogador.NaoRelacionado }
            );

            modelBuilder.Entity<Estadio>().HasData
            (
                // 🇺🇸 Estados Unidos (11)
                new Estadio() { Id = 1, Nome = "MetLife Stadium", Cidade = "East Rutherford (NY/NJ)", Capacidade = 82500m },
                new Estadio() { Id = 2, Nome = "SoFi Stadium", Cidade = "Los Angeles (CA)", Capacidade = 70240m },
                new Estadio() { Id = 3, Nome = "AT&T Stadium", Cidade = "Arlington (TX)", Capacidade = 80000m },
                new Estadio() { Id = 4, Nome = "Mercedes-Benz Stadium", Cidade = "Atlanta (GA)", Capacidade = 71000m },
                new Estadio() { Id = 5, Nome = "NRG Stadium", Cidade = "Houston (TX)", Capacidade = 72220m },
                new Estadio() { Id = 6, Nome = "Levi's Stadium", Cidade = "Santa Clara (CA)", Capacidade = 68500m },
                new Estadio() { Id = 7, Nome = "Lumen Field", Cidade = "Seattle (WA)", Capacidade = 68740m },
                new Estadio() { Id = 8, Nome = "Lincoln Financial Field", Cidade = "Philadelphia (PA)", Capacidade = 69596m },
                new Estadio() { Id = 9, Nome = "Hard Rock Stadium", Cidade = "Miami (FL)", Capacidade = 65326m },
                new Estadio() { Id = 10, Nome = "GEHA Field at Arrowhead Stadium", Cidade = "Kansas City (MO)", Capacidade = 76416m },
                new Estadio() { Id = 11, Nome = "Gillette Stadium", Cidade = "Foxborough (MA)", Capacidade = 65878m },
                
                new Estadio() { Id = 12, Nome = "BC Place", Cidade = "Vancouver", Capacidade = 54500m },
                new Estadio() { Id = 13, Nome = "BMO Field", Cidade = "Toronto", Capacidade = 30000m },
                
                new Estadio() { Id = 14, Nome = "Estadio Azteca", Cidade = "Cidade do México", Capacidade = 87000m },
                new Estadio() { Id = 15, Nome = "Estadio BBVA", Cidade = "Monterrey", Capacidade = 53500m },
                new Estadio() { Id = 16, Nome = "Estadio Akron", Cidade = "Guadalajara", Capacidade = 49850m }
            );

            //Área para futuros inserts no banco de dados a partir de outras classes/objetos
        }



        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .HaveColumnType("varchar").HaveMaxLength(200);

            base.ConfigureConventions(configurationBuilder);
        }

        //Inserir as linhas "new Jogador(){ Id = 1, ..." das lista de jogadores

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings
            .Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }

}

