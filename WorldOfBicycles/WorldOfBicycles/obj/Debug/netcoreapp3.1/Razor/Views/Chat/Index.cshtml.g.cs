#pragma checksum "C:\Users\Home\Desktop\WorldOfBicycles\WorldOfBicycles\WorldOfBicycles\Views\Chat\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b76894abbd0778f30d90476ef693fc880dbe77e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_Index), @"mvc.1.0.view", @"/Views/Chat/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76894abbd0778f30d90476ef693fc880dbe77e2", @"/Views/Chat/Index.cshtml")]
    public class Views_Chat_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/signalr/dist/browser/signalr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Home\Desktop\WorldOfBicycles\WorldOfBicycles\WorldOfBicycles\Views\Chat\Index.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Chat";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""p-5"">
        <div class=""pt-5"">
            <div id=""inputForm"">
                <input type=""text"" id=""message"" />
                <input class=""btn btn-danger mb-3"" type=""button"" id=""sendBtn"" value=""Отправить"" />
            </div>
            <div id=""chatroom""></div>

            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b76894abbd0778f30d90476ef693fc880dbe77e23552", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <script>
                const hubConnection = new signalR.HubConnectionBuilder()
                    .withUrl(""/chat"")
                    .build();

                // получение сообщения от сервера
                hubConnection.on('Receive', function (message, connectionId) {

                    // создаем элемент <b> для имени идентификатора подключения
                    let userNameElem = document.createElement(""b"");
                    userNameElem.appendChild(document.createTextNode(connectionId + "": ""));

                    // создает элемент <p> для сообщения пользователя
                    let elem = document.createElement(""p"");
                    elem.appendChild(userNameElem);
                    elem.appendChild(document.createTextNode(message));

                    var firstElem = document.getElementById(""chatroom"").firstChild;
                    document.getElementById(""chatroom"").insertBefore(elem, firstElem);

                });

                hu");
            WriteLiteral(@"bConnection.on('Notify', function (message) {

                    // добавляет элемент для диагностического сообщения
                    let notifyElem = document.createElement(""b"");
                    notifyElem.appendChild(document.createTextNode(message));
                    let elem = document.createElement(""p"");
                    elem.appendChild(notifyElem);
                    var firstElem = document.getElementById(""chatroom"").firstChild;
                    document.getElementById(""chatroom"").insertBefore(elem, firstElem);
                });

                // отправка сообщения на сервер
                document.getElementById(""sendBtn"").addEventListener(""click"", function (e) {
                    let message = document.getElementById(""message"").value;
                    hubConnection.invoke('Send', message);
                });

                hubConnection.start();
            </script>
        </div>
    </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591