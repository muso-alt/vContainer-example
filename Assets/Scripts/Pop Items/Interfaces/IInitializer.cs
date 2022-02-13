namespace Pop_Items.Interfaces
{
    public interface IInitializer<T>
    {
        void InitInternalData();
        void Initialize(T popItem);
        void Dispose();
    }
}