using Projeto_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace Projeto_BackEnd.Models

{

    public class SeedData

    {

        public static void EnsurePopulated(IApplicationBuilder app)

        {

            //associa os dados ao contexto

            Context context = app.ApplicationServices.GetRequiredService<Context>();

            //inserir os dados nas entidades do contexto

            context.Database.Migrate();

            //se o contexto estiver vazio

            if (!context.Personais.Any())

            {

                context.Personais.AddRange(

                new Personal { Nome = "Oloap", Especialidade = "Muscalacao" });

                context.Alunos.AddRange(

                new Aluno { Nome = "Paolo", Data_Nascimento= DateTime.Today,E_mail="Paolo@teste.com", Instagram= "Paolo",Telefone= "9999-9999",PersonalId= 1 });

                context.Treinos.AddRange(

                new Treino { PersonalId = 1, AlunoId = 1, Data = DateTime.Today,Hora= DateTime.Now });

                context.Exercicios.AddRange(

                new Exercicio { Nome = "Supino", Categoria = "peito", Descricao="empurra a barra para cima"});

                context.SaveChanges();

            }

        }

    }

}