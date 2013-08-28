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
using Sitecore.Text;
using Sitecore;
using Sitecore.Web.UI.Sheer;

namespace Glass.Mapper.Sc.Razor.Shell.Commands
{
    /// <summary>
    /// Class CreateBehindRazor
    /// </summary>
    public class CreateBehindRazor : Sitecore.Shell.Framework.Commands.Command
    {
        /// <summary>
        /// Executes the command in the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Execute(Sitecore.Shell.Framework.Commands.CommandContext context)
        {
            if (context.Items.Length == 1)
            {
                Sitecore.Data.Items.Item item = context.Items[0];

                ClientPipelineArgs args = new ClientPipelineArgs();

                System.Collections.Specialized.NameValueCollection parameters =
                new System.Collections.Specialized.NameValueCollection();
                parameters["id"] = item.ID.ToString();
                parameters["language"] = item.Language.ToString();
                parameters["database"] = item.Database.Name;

                args.Parameters = parameters;

                Sitecore.Context.ClientPage.Start(this, "Run", args);
            }
        }

        /// <summary>
        /// Runs the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        protected void Run(ClientPipelineArgs args)
        {
            UrlString str = new UrlString(UIUtil.GetUri("control:GlassBehindRazor", "id={AE723732-6D09-4DBA-B553-A1B399EB077D}&locationId=" + args.Parameters["id"]));

            if (!args.IsPostBack)
            {
                SheerResponse.ShowModalDialog(str.ToString(), true);
                args.WaitForPostBack();
            }
        }
    }
}

