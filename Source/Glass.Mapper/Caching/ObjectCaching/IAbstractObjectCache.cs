﻿using System.Collections.Generic;
using Glass.Mapper.Caching.CacheKeyResolving;
using Glass.Mapper.Pipelines.ObjectConstruction;

namespace Glass.Mapper.Caching.ObjectCaching
{
    public interface IAbstractObjectCache
    {
        string BaseCacheKey { get; set; }
        string DefaultBaseCacheKey { get; }
        object GetObject(ObjectConstructionArgs args);
        bool ContansObject(ObjectConstructionArgs args);
        void AddObject(ObjectConstructionArgs args);
        object GetObject(ICacheKey cacheKey);
        bool ContansObject(ICacheKey cacheKey);
        void AddObject(ICacheKey cacheKey, object objectForCaching);
        bool ClearCache();

        object GetFromRelatedCache(string objectKey);
        bool RelatedCacheContansObject(string objectKey);
        void AddToRelatedCache(string objectKey, IEnumerable<string> releatedKeys, object objectForCaching);
        void AddToRelatedCache(string objectKey, string releatedKey, object objectForCaching);
        bool ClearRelatedCache(string releatedKey);
        bool RemoveFromRelatedCache(string releatedKey);
        IDictionary<string, List<string>> GetRelatedKeys();

        ICacheKey GetLatestCacheKey(object id);
    }
}