using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Serilog;
using SerilogCurrentFileNameSample.Classes.Configurations;
using SerilogCurrentFileNameSample.Models;

namespace SerilogCurrentFileNameSample.Classes.Interceptors;

/// <summary>
/// Provides an implementation of <see cref="SaveChangesInterceptor"/> to log and audit changes
/// made to the database context during save operations.
/// </summary>
/// <remarks>
/// This class intercepts and inspects changes during the saving process, logging them using SeriLog.
/// It supports operations such as tracking added, modified, and deleted entities.
/// </remarks>
public class AuditInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new())
    {
        Inspect(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        Inspect(eventData);
        return base.SavingChanges(eventData, result);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        Inspect(eventData);
        return base.SavedChanges(eventData, result);
    }

    /// <summary>
    /// Inspects the changes tracked by the <see cref="DbContext"/> during a save operation 
    /// and logs the details of added, modified, or deleted entities.
    /// </summary>
    /// <param name="eventData">
    /// The event data containing the <see cref="DbContext"/> and other information about the save operation.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when an unexpected <see cref="EntityState"/> is encountered during inspection.
    /// </exception>
    private static void Inspect(DbContextEventData eventData)
    {
        var changesList = new List<CompareModel>();

        foreach (EntityEntry entry in eventData.Context!.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    changesList.Add(new CompareModel()
                    {
                        OriginalValue = null!,
                        NewValue = entry.CurrentValues.ToObject(),
                        EntityState = nameof(EntityState.Added)
                    });
                    break;
                case EntityState.Deleted:
                    changesList.Add(new CompareModel()
                    {
                        OriginalValue = entry.OriginalValues.ToObject(),
                        NewValue = null!,
                        EntityState = nameof(EntityState.Deleted)
                    });
                    break;
                case EntityState.Modified:
                    changesList.Add(new CompareModel()
                    {
                        OriginalValue = entry.OriginalValues.ToObject(),
                        NewValue = entry.CurrentValues.ToObject(),
                        EntityState = nameof(EntityState.Modified)
                    });
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Log.Information($"\nchange list:{changesList.ToJson()}");
        }
        
    }
}
