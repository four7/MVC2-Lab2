using MVC2_Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2_Lab2.ViewModels
{
    public class MovieListViewModel
    {
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public List<MovieViewModel> Items { get; set; } = new List<MovieViewModel>();
        public List<Film> filmLista { get; set; }
        public List<FilmActor> filmActors { get; set; }
        public Film filmerna { get; set; }
        public Actor actor { get; set; }
        public Category cat { get; set; }

        public MovieListViewModel()
        {
            filmActors = new List<FilmActor>();
            filmLista = new List<Film>();
            filmerna = new Film();
            actor = new Actor();
            cat = new Category();
        }

        public class MovieViewModel
        {
            public int MovieId { get; set; }
            public string MovieName { get; set; }
            public string ReleaseYear { get; set; }
        }
    }
}
