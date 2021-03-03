using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioGuanabara
{
    public class Movie : TMDB
    {

        public Movie(Configuracao config):base(config){}

        public override async Task<string> RetornarDesafio(int idFilme)
        {
            try
            {
                Model.Movie filme = await RetornarFilme(idFilme);

                return filme.Title + " / " + new string(filme.Title.Reverse().ToArray());

            } catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
