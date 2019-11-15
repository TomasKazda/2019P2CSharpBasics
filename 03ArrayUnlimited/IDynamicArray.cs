namespace ArrayUnlimited
{
    public interface IDynamicArray<T>
    {
        T Get(int position);
        T[] GetAll();
        void Add(T value);
        void Insert(T value, int position);
        bool Delete(T value);
        void Delete(int position);
        void ShiftItems(int indexFrom);
        int Count { get; }
        int Length { get; }
    }
}
