using System;
using System.Collections.Generic;
using System.Web.Http;

namespace JsonNetSample.Controller
{
    public class HomeController : ApiController
    {
        public HomeInfo Get()
        {
            return new HomeInfo();
        }
    }

    public class HomeInfo
    {
        private readonly DateTime _created = DateTime.UtcNow;
        private readonly Dictionary<int, string> _colorMap = new Dictionary<int, string>
        {
            { 1, "blue"},
            { 2, "red" },
            { 3, "green" },
            { 4, "black" },
            { 5, "white" },
        };

        public DateTime Created { get { return _created; } }

        public IDictionary<int, string> ColorMap { get { return _colorMap; } }
    }
}
