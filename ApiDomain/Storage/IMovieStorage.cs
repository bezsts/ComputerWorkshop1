using ApiDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Storage
{
    public interface IMovieStorage
    {
        IEnumerable<Movie> GetAll();
        Movie? Get(int id);
        Movie Add(Movie movie);
        bool Update(int id, Movie updatedMovie);
        int Delete(int id);
    }
}
