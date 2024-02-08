using Cardcraft.Data.Models;

namespace Cardcraft.Data.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllCardsAsync();

        Task<Card?> GetCardByIdAsync(int? id);

        Task<Card?> AddCardAsync(Card card);

        Task<Card?> UpdateCardAsync(Card card);

        Task DeleteCardByIdAsync(int id);

        Task DeleteAllCardsAsyc();
    }
}
