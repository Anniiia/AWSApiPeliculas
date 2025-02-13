﻿using AWSApiPeliculas.Data;
using AWSApiPeliculas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AWSApiPeliculas.Repositories
{
    public class RepositoryPeliculas
    {
        private PeliculasContext context;

        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }

        public async Task<List<Pelicula>> GetPeliculasAsync()
        {
            return await this.context.Peliculas.ToListAsync();
        }

        public async Task<List<Pelicula>> GetPeliculasActoresAsync(string actor)
        {
            List<Pelicula> peliculas = await this.context.Peliculas.Where(x => x.Actores.Contains(actor)).ToListAsync();

            return peliculas;
        }
    }
}
