using Cardcraft.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cardcraft.Data.Services
{
    public class CardService : ICardService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public CardService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _dbContextFactory = contextFactory; 
        }

        public async Task<IEnumerable<Card>> GetAllCardsAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Cards.OrderByDescending(c => c.Id).ToListAsync();
        }

        public async Task<Card?> GetCardByIdAsync(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Cards.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Card?> AddCardAsync(Card card)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.Cards.Add(card);
            await context.SaveChangesAsync();
            return card;
        }

        public async Task<Card?> UpdateCardAsync(Card card)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            if (card is not null)
            {
                context.Update(card);
                await context.SaveChangesAsync();
                return card;
            }
            return null;
        }

        public async Task DeleteCardByIdAsync(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var card = await context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card is not null)
            {
                context.Cards.Remove(card);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAllCardsAsyc()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var cards = await context.Cards.ToListAsync();
            context.Cards.RemoveRange(cards);
            await context.SaveChangesAsync();
        }
    }
}
