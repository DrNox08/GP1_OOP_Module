public interface ICollectible
{
    public string Name { get; }
    void Collect(ICollector collector);
}