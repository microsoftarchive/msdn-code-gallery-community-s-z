using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.SharePoint.Client;

namespace Zhukov.Blog.CustomSuiteBar
{
    [ServerStub(
       typeof(CustomSuiteNavService),
       TargetTypeId = "{97bb7990-9444-4f22-b5ad-dc8a5667041e}")]
    public class CustomSuiteNavServiceStub : ServerStub
    {
        protected override Type TargetType => typeof(CustomSuiteNavService);

        protected override Guid TargetTypeId => new Guid("{97bb7990-9444-4f22-b5ad-dc8a5667041e}");

        protected override string TargetTypeScriptClientFullName => "SP.Zhukov";

        protected override object InvokeConstructor(XmlNodeList xmlargs, ProxyContext proxyContext)
        {
            CheckBlockedMethod(".ctor", proxyContext);
            return new CustomSuiteNavService();
        }

        protected override object InvokeConstructor(ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            CheckBlockedMethod(".ctor", proxyContext);
            return new CustomSuiteNavService();
        }

        protected override object InvokeMethod(object target, string methodName, ClientValueCollection xmlargs, ProxyContext proxyContext, out bool isVoid)
        {
            var service = (CustomSuiteNavService)target;

            methodName = GetMemberName(methodName, proxyContext);

            switch (methodName)
            {
                case "Empty":
                    isVoid = true;
                    return null;
                case "GetSuiteNavData":
                    isVoid = true;
                    return service.GetSuiteNavData();
            }

            return base.InvokeMethod(target, methodName, xmlargs, proxyContext, out isVoid);
        }

        protected override IEnumerable<MethodInformation> GetMethods(ProxyContext proxyContext)
        {
            var methodGetString = new MethodInformation
            {
                Name = "GetSuiteNavData",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetSuiteNavData",
                WildcardPath = false,
                ReturnType = typeof(string),
                ReturnODataType = ODataType.Primitive,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return methodGetString;

            var methodCtor = new MethodInformation
            {
                Name = ".ctor",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.RESTful,
                OriginalName = ".ctor",
                WildcardPath = false,
                ReturnType = null,
                ReturnODataType = ODataType.Invalid,
                RESTfulExtensionMethod = false,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.None
            };
            yield return methodCtor;
        }

        protected override ClientLibraryTargets ClientLibraryTargets => ClientLibraryTargets.All;
    }
}
