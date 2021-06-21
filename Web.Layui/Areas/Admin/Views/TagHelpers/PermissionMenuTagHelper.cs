using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Admin.Views.TagHelpers
{
    public class PermissionMenuTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            StringBuilder output = new StringBuilder();
            if (_object.ListOfObjects.Count > 0)
            {
                output.Append("<ul>");

                foreach (MyObject subItem in _object.listOfObjects)
                {
                    output.Append("<li>");
                    output.Append(_object.Title);
                    output.Append(html.ShowSubItems(subItem.listOfObjects);
                    output.Append("</li>")
                }
                output.Append("</ul>");
            }
           


            return base.ProcessAsync(context, output);
        }
    }
}
