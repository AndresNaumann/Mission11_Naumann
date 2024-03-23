namespace Mission11_Naumann.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books {  get; }
    }
}
