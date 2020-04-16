using MVC2_Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2_Lab2.Service
{
    public class MovieService
    {
        public MovieListViewModel SortModel(MovieListViewModel Model, string sortOrder, string sortColumn)
        {
            if (string.IsNullOrEmpty(sortOrder))
                sortOrder = "asc";

            if (sortColumn == "title")
            {
                if (sortOrder == "asc")
                {
                    Model.Items = Model.Items.OrderBy(p => p.MovieName).ToList();
                }
                else
                {
                    Model.Items = Model.Items.OrderByDescending(p => p.MovieName).ToList();
                }

            }
            else if (sortColumn == "date")
            {
                if (sortOrder == "asc")
                {
                    Model.Items = Model.Items.OrderBy(p => p.ReleaseYear).ToList();
                }

                else
                {
                    Model.Items = Model.Items.OrderByDescending(p => p.ReleaseYear).ToList();
                }
            }
            else
            {
                if (sortOrder == "asc")
                {
                    Model.Items = Model.Items.OrderBy(p => p.MovieId).ToList();

                }
                else
                {
                    Model.Items = Model.Items.OrderByDescending(p => p.MovieId).ToList();
                }

                sortColumn = "id";
            }

            Model.SortColumn = sortColumn;
            Model.SortOrder = sortOrder;

            return Model;

        }
    }
}
