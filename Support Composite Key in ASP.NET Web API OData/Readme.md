# Support Composite Key in ASP.NET Web API OData
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- OData
- ASP.NET Web API
## Topics
- OData
- ASP.NET Web API
## Updated
- 02/05/2013
## Description

<p>The default EntitySetController&nbsp;doesn't support composite keys. So if you have composite key models, you need some additional work. Here is an example about how to do that.</p>
<p>The model is simple:</p>
<pre><code>public class Person
{
    [Key]
    public string FirstName { get; set; }
    [Key]
    public string LastName { get; set; }

    public int Age { get; set; }
}
</code></pre>
<p>The odata url for this model will look like:</p>
<pre><code>GET <a href="http://localhost:33051/People(FirstName=">http://localhost:33051/People(FirstName='Kate',LastName='Jones</a>') HTTP/1.1
</code></pre>
<p>And we want to have strong typed parameters in web api actions to this URL.</p>
<pre><code>    public Person Get([FromODataUri] string firstName, [FromODataUri] string lastName)
</code></pre>
<p>Note that the FromODataUri model binder attribute is used to parse from odata uri representation to clr type. In odata, string value is &quot;'xxx'&quot; and we want it to be &quot;xxx&quot;.</p>
<p>In order to make the route to work, you can add a custom routing convention to parse the key path. Here is a sample implementation:</p>
<pre><code>public class CompositeKeyRoutingConvention : EntityRoutingConvention
{
    public override string SelectAction(System.Web.Http.OData.Routing.ODataPath odataPath, System.Web.Http.Controllers.HttpControllerContext controllerContext, ILookup&lt;string, System.Web.Http.Controllers.HttpActionDescriptor&gt; actionMap)
    {
        var action = base.SelectAction(odataPath, controllerContext, actionMap);
        if (action != null)
        {
            var routeValues = controllerContext.RouteData.Values;
            if (routeValues.ContainsKey(ODataRouteConstants.Key))
            {
                var keyRaw = routeValues[ODataRouteConstants.Key] as string;
                IEnumerable&lt;string&gt; compoundKeyPairs = keyRaw.Split(',');
                if (compoundKeyPairs == null || compoundKeyPairs.Count() == 0)
                {
                    return action;
                }

                foreach (var compoundKeyPair in compoundKeyPairs)
                {
                    string[] pair = compoundKeyPair.Split('=');
                    if (pair == null || pair.Length != 2)
                    {
                        continue;
                    }
                    var keyName = pair[0].Trim();
                    var keyValue = pair[1].Trim();

                    routeValues.Add(keyName, keyValue);
                }
            }
        }

        return action;
    }
}
</code></pre>
<p>The convention is inherited from EntityRoutingConvention, which is the default convetion to handle entity key. By calling base.SelectAction, it will add the full key path into routeValues. The new convention will check if it contains &quot;,&quot; and seperate it
 into multiple keys and set each of them into routeValues. So when web api select actions, it will use those values to determine which action to choose. If there is no &quot;,&quot; found, it behaves same as base convetion.</p>
<p>To register the convetion, you need to set it when mapping odata route:</p>
<pre><code>public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        config.EnableQuerySupport();

        var mb = new ODataConventionModelBuilder(config);
        mb.EntitySet&lt;Person&gt;(&quot;People&quot;);

        var conventions = ODataRoutingConventions.CreateDefault();
        conventions.Insert(0, new CompositeKeyRoutingConvention());

        config.Routes.MapODataRoute(
            routeName: &quot;OData&quot;, 
            routePrefix: null, 
            model: mb.GetEdmModel(), 
            pathHandler: new DefaultODataPathHandler(), 
            routingConventions: conventions);
    }
}
</code></pre>
<p>Register the route at the postion 0 is to make it be executed before other default routing convetions. So the default EntityRoutingConvetion won't be executed before it. After that, you should be able to get routing work.</p>
<p>Then, how to build url for composite keys?&nbsp;<br>
You don't need to do that for odata links include edit link and self link when using ODataConventionModelBuilder. It will automatically identify composite keys and build the uri for you.</p>
<p>However, you need to build the link for location header. Here is a sample code from PeopleController.cs to handle post request:</p>
<pre><code>public HttpResponseMessage PostPerson(Person person)
{
    if (ModelState.IsValid)
    {
        _repo.UpdateOrAdd(person);

        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, person);
        string key = string.Format(
            &quot;{0}={1},{2}={3}&quot;,
            &quot;FirstName&quot;, ODataUriUtils.ConvertToUriLiteral(person.FirstName, Microsoft.Data.OData.ODataVersion.V3),
            &quot;LastName&quot;, ODataUriUtils.ConvertToUriLiteral(person.LastName, Microsoft.Data.OData.ODataVersion.V3));
        response.Headers.Location = new Uri(Url.ODataLink(
            new EntitySetPathSegment(&quot;People&quot;),
            new KeyValuePathSegment(key)));
        return response;
    }
    else
    {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
    }
}
</code></pre>
<p>Hope it helps.</p>
