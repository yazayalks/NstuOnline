using Common.Data.EntityFramework.Extensions;
using Common.Data.EntityFramework.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Infrastructure.Database.Repositories;

public class ChatRepository : RepositoryBase<Chat, Guid>, IChatRepository
{
    public ChatRepository(MessageContext context) : base(context)
    {
    }

    public async Task<PagedList<Chat>> Search(SearchChatCriteria criteria, CancellationToken cancellationToken)
    {
        var userChatIds = Context
            .Set<ChatUser>()
            .AsNoTracking()
            .Where(x => x.UserId == criteria.UserId)
            .Select(x => x.ChatId);
        
        var query = EntitiesDbSet
            .AsNoTracking()
            .Where(x => userChatIds.Contains(x.Id));

        if (criteria.ChatTypeId.HasValue)
        {
            query = query.Where(x => x.ChatTypeId == criteria.ChatTypeId.Value);
        }
        
        if (!string.IsNullOrWhiteSpace(criteria.Keyword))
        {
            query = query.Where(x => EF.Functions.ILike(x.Name, $"%{criteria.Keyword}%"));
        }

        return await query.ToSearchResult(
            criteria.SortExpressions,
            criteria.Skip,
            criteria.Take,
            cancellationToken: cancellationToken);
    }
}