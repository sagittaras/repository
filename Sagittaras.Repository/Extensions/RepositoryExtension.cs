using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sagittaras.Repository.Extensions;

/// <summary>
///     Helpful extension methods for the repository.
/// </summary>
public static class RepositoryExtension
{
    /// <summary>
    ///     Gets all repository keys.
    /// </summary>
    /// <param name="repository"></param>
    public static IEnumerable<IKey> GetKeys(this IRepository repository)
    {
        return repository.EntityType.GetKeys();
    }

    /// <summary>
    ///     Gets a repository PK description.
    /// </summary>
    /// <param name="repository"></param>
    /// <returns></returns>
    public static IKey GetPrimaryKey(this IRepository repository)
    {
        return GetKeys(repository).Single(x => x.IsPrimaryKey());
    }

    /// <summary>
    ///     Get a property of non-composite PK.
    /// </summary>
    /// <param name="repository"></param>
    /// <exception cref="InvalidOperationException">Repository has composite PK.</exception>
    /// <returns></returns>
    public static IProperty GetPrimaryKeyProperty(this IRepository repository)
    {
        return GetPrimaryKey(repository).Properties.Single();
    }

    /// <summary>
    ///     Get properties of composite PK.
    /// </summary>
    /// <param name="repository"></param>
    /// <returns></returns>
    public static IReadOnlyList<IProperty> GetPrimaryKeyProperties(this IRepository repository)
    {
        return GetPrimaryKey(repository).Properties;
    }
}