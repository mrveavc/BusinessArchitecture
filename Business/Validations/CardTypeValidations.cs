using Business.Tools.Exceptions;
using Entities.Models;

namespace Business.Validations;

public class CardTypeValidations
{
    public async Task CardTypeMustNotBeEmpty(CardType? cardType)
    {
        if (cardType == null)
        {
            throw new ValidationException("CardType must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}
