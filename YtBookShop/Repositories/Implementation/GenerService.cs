using YtBookStore.Models.Domain;
using YtBookStore.Repositories.Abstract;

namespace YtBookStore.Repositories.Implementation
{
    public class GenerService : IGenreService
    {
        private readonly DatabaseContext context;

        public GenerService(DatabaseContext context)
        {
            this.context = context;
        }
        bool IGenreService.Add(Genre model)
        {
            try
            {
                context.Genre.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        bool IGenreService.Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if(data == null) 
                    return false;

                context.Genre.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre FindById(int id)
        {
            return context.Genre.Find(id);
        }

        

        IEnumerable<Genre> IGenreService.GetAll()
        {
            return context.Genre.ToList();
        }

        bool IGenreService.Update(Genre model)
        {


            try
            {
                context.Genre.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
