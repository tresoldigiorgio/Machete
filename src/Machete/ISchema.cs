﻿namespace Machete
{
    using System;


    public interface ISchema<TSchema>
        where TSchema : Entity
    {
        /// <summary>
        /// Map a parsed text fragment to an entity
        /// </summary>
        /// <param name="slice"></param>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool TryConvertEntity<T>(TextSlice slice, out T entity)
            where T : TSchema;

        /// <summary>
        /// Retrieve an entity factory for the specified entity type
        /// </summary>
        /// <param name="entityFactory">The entity factory</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>True if the entity factory exists, otherwise false</returns>
        bool TryGetEntityFactory<T>(out IEntityFactory<T> entityFactory)
            where T : TSchema;

        /// <summary>
        /// Returns the layout specified, if present.
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T">The layout type</typeparam>
        /// <returns></returns>
        bool TryGetLayout<T>(out ILayoutParserFactory<T, TSchema> result)
            where T : Layout;

        /// <summary>
        /// Returns a dynamic implementation type for the schema type
        /// </summary>
        /// <typeparam name="T">The schema type</typeparam>
        /// <returns>A concrete type which backs the schema type</returns>
        Type GetImplementationType<T>();
    }
}