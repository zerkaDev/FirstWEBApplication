#pragma checksum "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\Account\Settings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2d7af10f3e5d578b7254d3873b0af4fd6439f37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Settings), @"mvc.1.0.view", @"/Views/Account/Settings.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\_ViewImports.cshtml"
using MyFirstWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\_ViewImports.cshtml"
using MyFirstWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\_ViewImports.cshtml"
using MyFirstWebApp.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2d7af10f3e5d578b7254d3873b0af4fd6439f37", @"/Views/Account/Settings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5a3b3ce7e1fa2c633e6146b2de15685ba849754", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Settings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\Account\Settings.cshtml"
Write(await Html.PartialAsync("_accSideBar"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"text-md-center\">\r\n    <div class=\"hide py-2\">\r\n        <input readonly");
            BeginWriteAttribute("value", " value=\"", 136, "\"", 160, 1);
#nullable restore
#line 5 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\Account\Settings.cshtml"
WriteAttributeValue("", 144, Model.FirstName, 144, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n    <div class=\"hide py-2\">\r\n        <input readonly");
            BeginWriteAttribute("value", " value=\"", 230, "\"", 253, 1);
#nullable restore
#line 8 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\Account\Settings.cshtml"
WriteAttributeValue("", 238, Model.LastName, 238, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n    <div class=\"hide py-2\">\r\n        <input readonly");
            BeginWriteAttribute("value", " value=\"", 323, "\"", 341, 1);
#nullable restore
#line 11 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\Account\Settings.cshtml"
WriteAttributeValue("", 331, Model.Age, 331, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n    <div class=\"hide py-2\">\r\n        <input readonly");
            BeginWriteAttribute("value", " value=\"", 411, "\"", 431, 1);
#nullable restore
#line 14 "C:\Users\User\source\repos\MyFirstWebApp\MyFirstWebApp\Views\Account\Settings.cshtml"
WriteAttributeValue("", 419, Model.Login, 419, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
