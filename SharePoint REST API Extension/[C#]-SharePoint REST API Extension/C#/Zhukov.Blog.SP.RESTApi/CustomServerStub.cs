using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.SharePoint.Client;

namespace Zhukov.Blog.SP.REST
{
    [ServerStub(
        typeof(CustomService), 
        TargetTypeId = "{7954fe10-6ba6-4cc0-9fcf-e23a04816790}")]
    public class CustomServerStub : ServerStub
    {
        protected override Type TargetType => typeof(CustomService);

        protected override Guid TargetTypeId => new Guid("{7954fe10-6ba6-4cc0-9fcf-e23a04816790}");

        protected override string TargetTypeScriptClientFullName => "SP.Zhukov";

        protected override object GetProperty(object target, string propName, ProxyContext proxyContext)
        {
            propName = GetMemberName(propName, proxyContext);
            switch (propName)
            {
                case "About":
                    CheckBlockedGetProperty("About", proxyContext);
                    return ((CustomService)target).About;
            }

            return base.GetProperty(target, propName, proxyContext);
        }

        protected override object InvokeConstructor(XmlNodeList xmlargs, ProxyContext proxyContext)
        {
            CheckBlockedMethod(".ctor", proxyContext);
            return new CustomService();
        }

        protected override object InvokeConstructor(ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            CheckBlockedMethod(".ctor", proxyContext);
            return new CustomService();
        }

        protected override object InvokeMethod(object target, string methodName, ClientValueCollection xmlargs, ProxyContext proxyContext, out bool isVoid)
        {
            var service = (CustomService)target;

            methodName = GetMemberName(methodName, proxyContext);

            switch (methodName)
            {
                case "Empty":
                    isVoid = true;
                    return null;
                case "GetString":
                    isVoid = true;
                    return service.GetString();
            }

            return base.InvokeMethod(target, methodName, xmlargs, proxyContext, out isVoid);
        }

        protected override IEnumerable<MethodInformation> GetMethods(ProxyContext proxyContext)
        {
            var methodGetString = new MethodInformation
            {
                Name = "GetString",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetString",
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

        protected override IEnumerable<PropertyInformation> GetProperties(ProxyContext proxyContext)
        {
            var propAbout = new PropertyInformation
            {
                Name = "About",
                IsStatic = false,
                PropertyODataType = ODataType.Primitive,
                ExcludeFromDefaultRetrieval = false,
                PropertyType = typeof(string),
                ReadOnly = false,
                RequiredForHttpPutRequest = true,
                DefaultValue = false,
                OriginalName = "About",
                RESTfulPropertyType = null,
                RequiredRight = ResourceRight.Default
            };

            yield return propAbout;
        }

        protected override ClientLibraryTargets ClientLibraryTargets => ClientLibraryTargets.All;
    }
}
