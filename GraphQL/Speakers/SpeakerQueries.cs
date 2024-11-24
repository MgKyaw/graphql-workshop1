using ConferencePlanner.GraphQL.Data;
using GreenDonut.Selectors;
using HotChocolate.Execution.Processing;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Speakers;

[QueryType]
public static class SpeakerQueries
{
    public static async Task<IEnumerable<Speaker>> GetSpeakersAsync(
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Speakers.AsNoTracking().ToListAsync(cancellationToken);
    }

    public static async Task<Speaker?> GetSpeakerAsync(
        int id,
        ISpeakerByIdDataLoader speakerById,
        ISelection selection,
        CancellationToken cancellationToken)
    {
        return await speakerById.Select(selection).LoadAsync(id, cancellationToken);
    }
}