﻿using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Alura.ListaLeitura.App
{ 
    public class Startup
    {
        
        // fluxo pipe line
        public void Configure(IApplicationBuilder app)
        {
            app.Run(Roteamento);
        }

        //requisicao
        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            var caminhosAtendidos = new Dictionary<string, string>
            {
                { "/Livros/ParaLer",_repo.ParaLer.ToString() },
                { "/Livros/Lendo", _repo.Lendo.ToString() },
                { "/Livros/Lidos,", _repo.Lidos.ToString() }
            };

            
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                return context.Response.WriteAsync(caminhosAtendidos[context.Request.Path]);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho Inexistente.");
        
        }

        //resposta
        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            return context.Response.WriteAsync(_repo.ParaLer.ToString());
            
        }   
                



            
        
        
    }
}