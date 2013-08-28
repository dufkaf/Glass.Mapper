/*
   Copyright 2012 Michael Edwards
 
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
//-CRE-

using System.Collections.Generic;
using Castle.DynamicProxy;

namespace Glass.Mapper.Pipelines.ObjectConstruction.Tasks.CreateInterface
{
    /// <summary>
    /// Class InterfacePropertyInterceptor
    /// </summary>
    public class InterfacePropertyInterceptor : IInterceptor
    {
        private readonly ObjectConstructionArgs _args;
        Dictionary<string, object> _values;
        bool _isLoaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterfacePropertyInterceptor"/> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public InterfacePropertyInterceptor(ObjectConstructionArgs args)
        {
            _args = args;
        }

        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <exception cref="Glass.Mapper.MapperException">Method with name {0}{1} on type {2} not supported..Formatted(method, name, _args.Configuration.Type.FullName)</exception>
        public void Intercept(IInvocation invocation)
        {
            //do initial gets
            if (!_isLoaded)
            {
                _values = new Dictionary<string, object>();
                var config = _args.Configuration;
                var mappingContext = _args.Service.CreateDataMappingContext(_args.AbstractTypeCreationContext, null);

                foreach (var property in config.Properties)
                {
                    var result = property.Mapper.MapToProperty(mappingContext);
                    _values[property.PropertyInfo.Name] = result;
                }
                _isLoaded = true;
            }

            if (invocation.Method.IsSpecialName)
            {
                if (invocation.Method.Name.StartsWith("get_") || invocation.Method.Name.StartsWith("set_"))
                {

                    string method = invocation.Method.Name.Substring(0, 4);
                    string name = invocation.Method.Name.Substring(4);

                    if (method == "get_")
                    {
                        var result = _values[name];
                        invocation.ReturnValue = result;
                    }
                    else if (method == "set_")
                    {
                        _values[name] = invocation.Arguments[0];
                    }
                    else
                        throw new MapperException("Method with name {0}{1} on type {2} not supported.".Formatted(method, name, _args.Configuration.Type.FullName));
                }
            }
        }
    }
}




