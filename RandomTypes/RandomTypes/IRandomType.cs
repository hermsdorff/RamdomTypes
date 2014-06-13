namespace RandomTypes
{
    public interface IRandomType<T>
    {
        T GetNext();
    }
}