namespace ContactsAPI.Backend.Interfaces;

public interface IEntityRepository<T>
{
    Task<IEnumerable<T>> GetItemsAsync();
    Task<T?> GetItemByIdAsync(string id);
    Task InsertItemAsync(T item);
    Task<bool> DeleteItemByIdAsync(string id);
    Task UpdateItemAsync(T item);
    Task<bool> ItemExistsAsync(string id);
}