using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Web.Layui.Views.TagHelpers
{
    
    public class WebSiteMenuTagHelper : TagHelper
    {
        public WebSiteMenuTagHelper()
        {

        }
        public List<EntitysModels.WebSite_Menu> MenuList { get; set; }
        public string UrlPath { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // <ul class="navbar-nav">
            output.TagName = "ul";
            output.Attributes.Add("class", "navbar-nav");
            StringBuilder sbHtml = new StringBuilder();



            //class='nav-item {3}'

            StrBuilderHtml(sbHtml, MenuList.Where(x => x.MenuPid == 0).ToList(), "", "");
            output.Content.SetHtmlContent(sbHtml.ToString());
            return base.ProcessAsync(context, output);
        }
       
        public void StrBuilderHtml(StringBuilder sbHtml, List<EntitysModels.WebSite_Menu> models, string tagStr,string classStyle)
        {
            if (Equals(null, models)|| models.Count<1) { return; }
            foreach (var m in models)
            {
                sbHtml.Append("<li class='");
               

                if (m.MenuName.ToLower().Contains(UrlPath.ToLower()))
                {
                    sbHtml.Append(" active");
                }

                var EnumerableMenu = MenuList.Where(x => x.MenuPid == m.MenuID);

                string urlMenuStr = string.IsNullOrWhiteSpace(m.MenuUrl) ? "#" : m.MenuUrl;
                if (EnumerableMenu.Any())
                {
                    sbHtml.Append(" nav-item dropdown'>");
                   
                    sbHtml.Append("<a class='nav-link dropdown-toggle' href='"+ urlMenuStr + "' data-bs-toggle='dropdown'>"+m.MenuName+"</a>");
                    sbHtml.Append("<ul class='dropdown-menu'>");
                    StrBuilderHtml(sbHtml, EnumerableMenu.ToList(), "dropdown", "dropdown");
                    sbHtml.Append("</ul>");
                    sbHtml.Append("</li>");
                    
                }
                else 
                {
                    
                    if (tagStr.Contains("dropdown"))
                    {
                        sbHtml.Append("'>");
                        sbHtml.Append("<a class='dropdown-item' href='" + urlMenuStr + "' >" + m.MenuName + "</a>");
                    }
                    else
                    {
                        sbHtml.Append(" nav-item'>");
                        sbHtml.Append("<a class='nav-link' href='" + urlMenuStr + "' >" + m.MenuName + "</a>");
                    }
                    
                    sbHtml.Append("</li>");
                }
                

            }

        }
    }
}
