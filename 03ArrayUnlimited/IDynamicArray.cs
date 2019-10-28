namespace ArrayUnlimited
{
    public interface IDynamicArray
    {
        object Get(int position);
        object[] GetAll();
        void Add(object value);
        void Insert(object value, int position);
        void ShiftItems(int indexFrom);
        int Count { get; }
        int Length { get; }
    }
}
