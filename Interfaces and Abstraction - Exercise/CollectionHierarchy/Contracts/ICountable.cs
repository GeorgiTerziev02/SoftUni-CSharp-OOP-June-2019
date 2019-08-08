namespace CollectionHierarchy.Contracts
{
    public interface ICountable : IRemovable
    {
        int Used { get; }
    }
}
