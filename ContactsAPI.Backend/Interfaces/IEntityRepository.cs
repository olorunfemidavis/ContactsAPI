namespace ContactsAPI.Backend.Interfaces;

public interface IEntityRepository<T>
{
    Task<T?> GetItemByIdAsync(string id);
    Task InsertItemAsync(T item);
    Task DeleteItemByIdAsync(string id);
    Task UpdateItemAsync(T item);
    Task<bool> ItemExistsAsync(string id);


    #region Test Methods

    Task<IEnumerable<T>> GetAllItemsAsync();


    #endregion
}