
using Core.Entities;
using Entities.Models;

namespace Entities.DTOs;

public class AddCardDto
{
    public Guid UserId { get; set; }
    public Guid CardTypeId { get; set; }
    public long CardUID { get; set; }
    public decimal Limit { get; set; }

    public Card GetCard()
    {
        return new()
        {

            UserId = UserId,
            CardTypeId = CardTypeId,
            CardUID = CardUID,
            Limit = Limit,
        };
    }

}

public class ViewCardDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CardTypeId { get; set; }
    public long CardUID { get; set; }
    public decimal Limit { get; set; }

    public ViewCardDto(Card card)
    {
        Id = card.Id;
        UserId = card.UserId;
        CardTypeId = card.CardTypeId;
        CardUID = card.CardUID;
        Limit = card.Limit;
    }
}