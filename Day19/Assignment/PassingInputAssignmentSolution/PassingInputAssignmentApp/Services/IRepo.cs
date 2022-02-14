namespace PassingInputAssignmentApp.Services
{
    public interface IRepo<K, T>
    {
        ICollection<T> GetAll();
        T Get(K k);
        T Add(T item);
        bool Remove(K id);
        bool Update(T item);
    }
}
