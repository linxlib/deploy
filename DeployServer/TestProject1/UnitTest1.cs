using LiteDB;
using Microsoft.Web.Administration;
using Newtonsoft.Json;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestIIS()
        {
            var manager = new ServerManager();
            manager.Sites.ToList().ForEach(e =>
            {
                Console.WriteLine(e.Name);
            });
        }
        [Test]
        public void Test1()
        {
            var str = @"{
        ""Timestamp"": 1682063487,
        ""Machine"": 13648039,
        ""Pid"": 4588,
        ""Increment"": 4089269,
        ""CreationTime"": ""2023-04-21T07:51:27Z""
      }";
            
            var a = JsonConvert.DeserializeObject<ObjectId>(str);
            Console.WriteLine(a.ToString());



        }
    }
}