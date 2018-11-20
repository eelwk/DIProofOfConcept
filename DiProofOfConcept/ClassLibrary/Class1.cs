using System;

namespace ClassLibrary
{
    public class TestClass
    {
        private IPrimaryInterface _primaryInterface;

        public TestClass(IPrimaryInterface primaryInterface)
        {
            _primaryInterface = primaryInterface;
        }

        public string TestMethod(string hello, string world)
        {
            return _primaryInterface.ThisIsAMethod(hello, world);
        }
    }
}
