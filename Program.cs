using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using WebScrapingRobot.Model;
using WebScrapingRobot.Repository;

namespace WebScrapingRobot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            Console.WriteLine("Iniciando a extração das oportunidades do fbo.gov;");

            DateTime dataHoraExtracao = DateTime.Now;

            var seleniumConfigurations = new SeleniumConfigurations();
            new ConfigureFromConfigurationOptions<SeleniumConfigurations>(
                configuration.GetSection("SeleniumConfigurations")
                ).Configure(seleniumConfigurations);

            var pagina = new PaginaFBO(seleniumConfigurations);
            pagina.CarregarPagina();
            pagina.PreencheFiltroPesquisa();

            var lastPage = pagina.GetLastPage();
            if(lastPage > 0)
            {
                LerPagina(pagina, lastPage);
            }

            pagina.Fechar();
        }

        private static void LerPagina(PaginaFBO pagina, int lastPage)
        {
            var postRepository = new PostRepository();
            
            for (int i = 1; i <= lastPage; i++)
            {
                List<Post> posts = new List<Post>();
                pagina.MudarPagina(i);

                for (int j = 0; j < 100; j++)
                {
                    var post = pagina.GetPost(j);
                    posts.Add(post);
                }

                postRepository.AddRange(posts);
            }
        }
    }
}
