﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mapper.Caching.Proxy;

namespace Glass.Mapper.Pipelines.ObjectConstruction.Tasks.ObjectCachingSaver
{
    public class ObjectCachingSaverTask : ObjectConstructionTask
    {
        public override void Execute(ObjectConstructionArgs args)
        {
            if (args.DisableCache) return;

            //Save item to the cache
            args.ObjectCacheConfiguration.ObjectCache.AddObject(args);

            args.Result = CacheProxyGenerator.CreateProxy(args.Result);
        }
    }
}
