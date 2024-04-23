namespace App.Services;

public class ModificationTechnologyCardService
{
    public async Task<Result> UpdateModificationContaining(Guid productId, ProductContaining containing)
    {
        var getproductContainingResult = await _store.GetModificationById(productId);

        if (getproductContainingResult.IsFailure)
        {
            return getproductContainingResult;
        }

        var modificationContaining = getproductContainingResult.Value;

        var updateContainingResult = modificationContaining.UpdateContaining(containing);

        if (updateContainingResult.IsFailure)
        {
            return updateContainingResult;
        }

        return await _store.SaveChanges(modificationContaining);
    }
    
    public async Task<Result> DeleteModificationContaining(Guid productId, ProductContaining containing)
    {
        var getProductContainingResult = await _store.GetModificationById(productId);

        if (getProductContainingResult.IsFailure)
        {
            return getProductContainingResult;
        }

        var modificationContaining = getProductContainingResult.Value;

        var updateContainingResult = modificationContaining.RemoveContaining(containing);

        if (updateContainingResult.IsFailure)
        {
            return updateContainingResult;
        }

        return await _store.SaveChanges(modificationContaining);
    }
    
}