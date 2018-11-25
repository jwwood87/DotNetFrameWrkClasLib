using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DotNetFrameworkClassLibrary.Core
{
    public abstract class TestBase
    {
        private Config _config = new Config();
        private string _timeStamp = DateTime.Now.ToString();
        private static IDictionary<string, TestDataContainer> testDataCollection;
        public static IDictionary<string, TestDataContainer> TestDataCollection
        {
            get { return testDataCollection ?? (testDataCollection = new Dictionary<string, TestDataContainer>()); }
            set { testDataCollection = value; }
        }

        [SetUp]
        public virtual void TestBaseSetUp()
        {
            Console.WriteLine(_timeStamp + ": Entering TestBase SetUp.");
            testDataCollection = new Dictionary<string, TestDataContainer>();
        }

        [TearDown]
        public virtual void TestBaseTearDown()
        {
            try
            {
                Console.WriteLine(DateTime.Now.ToString() + ": Entering TestBase TearDown.");
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }

        public static TestDataContainer TestData
        {
            get
            {
                var name = "test" + CommonStaticHelpers.GetRandomString();
                var container = new TestDataContainer(name);
                testDataCollection.Add(name, container);
                return testDataCollection[name];
            }
        }
    }
}
