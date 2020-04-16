using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2_Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2_Lab2.ViewModels
{
    public class PagingViewModel
    {
        public int CurrentPage { get; set; }
        public int MaxPages { get; set; }
        public string SelectedPageSize { get; set; }
        public SelectList PageSizeList { get; set; }
        public int PageSize { get; set; }

        public bool ShowPrevButton
        {
            get { return CurrentPage > 1; }
        }

        //NÄR SKA VI INTE BISA NEXY BUTTON??
        //När vi står på sista sidan
        public bool ShowNextButton
        {
            get { return CurrentPage < MaxPages; }
        }
    }
    //public abstract class PagedResultBase
    //{
    //    public int CurrentPage { get; set; }
    //    public int PageCount { get; set; }
    //    public int PageSize { get; set; }
    //    public int RowCount { get; set; }

    //    public int FirstRowOnPage
    //    {
    //        get { return (CurrentPage - 1) * PageSize + 1; }
    //    }

    //    public int LastRowOnPage
    //    {
    //        get { return Math.Min(CurrentPage * PageSize, RowCount); }
    //    }
    //}

    //public class PagedResult<T> : PagedResultBase where T : class 
    //{
    //    public IList<T> Results { get; set; }
    //    public PagedResult()
    //    {
    //        Results = new List<T>();
    //    }
    //}

    //public static class PageQuery
    //{
    //    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
    //                                     int page, int pageSize) where T : class
    //    {
    //        var result = new PagedResult<T>();
    //        result.CurrentPage = page;
    //        result.PageSize = pageSize;
    //        result.RowCount = query.Count();


    //        var pageCount = (double)result.RowCount / pageSize;
    //        result.PageCount = (int)Math.Ceiling(pageCount);

    //        var skip = (page - 1) * pageSize;
    //        result.Results = query.Skip(skip).Take(pageSize).ToList();

    //        return result;
    //    }
    //}
    public class MovieListViewModel
    {
        public PagingViewModel PagingViewModel { get; set; } = new PagingViewModel();
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public List<MovieViewModel> Items { get; set; } = new List<MovieViewModel>();
        //public List<Film> filmLista { get; set; }
        //public List<FilmActor> filmActors { get; set; }
        public Film filmerna { get; set; }
        //public Actor actor { get; set; }
        //public Category cat { get; set; }

        public MovieListViewModel()
        {
            //filmActors = new List<FilmActor>();
            //filmLista = new List<Film>();
            filmerna = new Film();
            //actor = new Actor();
            //cat = new Category();
        }

        public class MovieViewModel
        {
            public int MovieId { get; set; }
            public string MovieName { get; set; }
            public string ReleaseYear { get; set; }
        }
        
    }
}
