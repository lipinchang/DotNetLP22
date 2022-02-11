namespace SampleMVCTogetherApp.Services
{
    public interface IRepo<K, T>  //K is id. T is object
    {
        ICollection<T> GetAll();
        T Get(K k);
        bool Add(T item);
        bool Remove(K id);
        bool Update(T item);
    }
}
