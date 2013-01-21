﻿/*
   Copyright 2011 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Glass.Mapper.Sc.Configuration.Fluent
{

    /// <summary>
    /// Used to map item information to a class property
    /// </summary>
    public class SitecoreInfo<T> : AbstractPropertyBuilder<T, SitecoreInfoConfiguration>
    {

        public SitecoreInfo(Expression<Func<T, object>> ex):base(ex){
        }

        /// <summary>
        /// The type of information that should populate the property
        /// </summary>
        public SitecoreInfo<T> InfoType(SitecoreInfoType type)
        {
            Configuration.Type = type;
            return this;
        }
        /// <summary>
        /// UrlOptions, use in conjunction with SitecoreInfoType.Url
        /// </summary>
        public SitecoreInfo<T> UrlOptions(SitecoreInfoUrlOptions option)
        {
            Configuration.UrlOptions = option;
            return this;
        }


    }
}
