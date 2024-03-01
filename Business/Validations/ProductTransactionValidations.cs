using Business.Tools.Exceptions;
using Entities.Models;

namespace Business.Validations;

public class ProductTransactionValidations
{
    public async Task ProductTransactionMustNotBeEmpty(ProductTransaction? productTransaction)
    {
        if (productTransaction == null)
        {
            throw new ValidationException("productTransaction must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}
