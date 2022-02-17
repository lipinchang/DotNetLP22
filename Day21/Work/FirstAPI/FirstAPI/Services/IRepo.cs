namespace FirstAPI.Services
{
    public interface IRepo<K, T>where T : class
    {
        T Add(T item);
        T Get(T item);
        T Delete(K id);
        ICollection<T> GetAll();
        bool Remove(K id);
        bool Update(T item);
    }
}

