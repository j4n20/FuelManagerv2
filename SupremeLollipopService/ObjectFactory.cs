namespace SupremeLollipopService
{
    class ObjectFactory<T> where T : class, new()
    {
        public T CreateInstance()
        {
            return new T();
        }
    }
}
