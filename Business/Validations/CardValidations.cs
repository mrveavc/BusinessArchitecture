using Business.Tools.Exceptions;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstracts;
using Entities.Models;

namespace Business.Validations;

public class CardValidations
{
    public async Task CardMustNotBeEmpty(Card? card)
    {
        if (card == null)
        {
            throw new ValidationException("Card must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}
