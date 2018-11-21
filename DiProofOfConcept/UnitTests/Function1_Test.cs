using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using FunctionApp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using FunctionApp_TestHelper;
using ClassLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests
{
    [TestClass]
    public class Function1_Test : FunctionTest
    {
        private readonly ILogger _logger = NullLoggerFactory.Instance.CreateLogger("test");
        private IPrimaryInterface _primary;

        [TestInitialize]
        public void InitializeContainer()
        {
            var services = new ServiceCollection();
            services.AddClassLibraryDependencies();

            var provider = services.BuildServiceProvider();

            _primary = provider.GetService<IPrimaryInterface>();
        }

        [TestMethod]
        public async Task Request_With_Query()
        {
            var query = new Dictionary<String, StringValues>();
            query.TryAdd("name", "kathy");
            var body = "";           

            var result = await Function1.Run(req: HttpRequestSetup(query, body), primaryInterface: _primary, log: _logger);
            var resultObject = (OkObjectResult)result;
            Assert.AreEqual("Hello, You sent me hello kathy. Thank you for calling me! Have a nice day!", resultObject.Value);

        }

        [TestMethod]
        public async Task Request_Without_Query()
        {
            var query = new Dictionary<String, StringValues>();
            var body = "{\"name\":\"lee\"}";

            var result = await Function1.Run(HttpRequestSetup(query, body), _primary, _logger);
            var resultObject = (OkObjectResult)result;
            Assert.AreEqual("Hello, You sent me hello lee. Thank you for calling me! Have a nice day!", resultObject.Value);

        }

        [TestMethod]
        public async Task Request_Without_Query_And_Body()
        {
            var query = new Dictionary<String, StringValues>();
            var body = "";
            var result = await Function1.Run(HttpRequestSetup(query, body), _primary, _logger);
            var resultObject = (BadRequestObjectResult)result;
            Assert.AreEqual("Please pass a name on the query string or in the request body", resultObject.Value);
        }
    }
}
