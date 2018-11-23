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
        public virtual void SetUpTestBase()
        {
            testDataCollection = new Dictionary<string, TestDataContainer>();
            Console.WriteLine("We're started with SetUpTestBase");

        }

        [TearDown]
        public virtual void TearDownTestBase()
        {
            try
            {
                Console.WriteLine("We're finished with TearDownTestBase");
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
                var name = "test";
                var container = new TestDataContainer(name);
                testDataCollection.Add(name, container);
                return testDataCollection[name];
            }

        }
    }
}
