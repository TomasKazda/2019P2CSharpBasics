namespace RoboFactory.Interface
{
    public interface IDrill
    {
        int MaxSize { get; }
        int MaxRotations { get; }
        int Size { get; }
        int Rotations { get; }
        int SetSize(int size);
        int SetRotations(int rotations);
    }
}
