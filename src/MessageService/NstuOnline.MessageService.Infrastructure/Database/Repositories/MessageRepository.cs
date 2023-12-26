using Common.Data.EntityFramework.Extensions;
using Common.Data.EntityFramework.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class MessageRepository : RepositoryBase<Message, Guid>, IMessageRepository
{
    public MessageRepository(MessageContext context) : base(context)
    {
    }

    public async Task<PagedList<Message>> Search(SearchMessageCriteria criteria, CancellationToken cancellationToken)
    {
        var query = EntitiesDbSet
            .AsNoTracking()
            .Where(x => x.UserId == criteria.UserId && x.ChatId == criteria.ChatId);

        if (!string.IsNullOrWhiteSpace(criteria.Keyword))
        {
            query = query.Where(x => EF.Functions.ILike(x.Text, $"%{criteria.Keyword}%"));
        }

        return await query.ToSearchResult(
            criteria.SortExpressions,
            criteria.Skip,
            criteria.Take,
            cancellationToken: cancellationToken);
    }

    public async Task<PagedList<Message>> SimplifySearch(SimplifySearchMessageCriteria criteria,
        CancellationToken cancellationToken)
    {
        var query = EntitiesDbSet
            .AsNoTracking();

        if (criteria.ChatIds is not null)
        {
            query = query.Where(x => criteria.ChatIds.ToList().Contains(x.ChatId));
        }

        if (criteria.IsLast)
        {
            query = query
                .GroupBy(m => m.ChatId)
                .Select(g => g.OrderByDescending(m => m.CreateDate).FirstOrDefault());
        }

        return await query.ToSearchResult(
            criteria.SortExpressions,
            criteria.Skip,
            criteria.Take,
            cancellationToken: cancellationToken);
    }
}