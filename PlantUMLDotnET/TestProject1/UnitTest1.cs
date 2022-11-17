using Newtonsoft.Json;
using PlantUML.Lib;
using plantumldotnetparser.Lib.DataClasses;

namespace TestProject1
{
    public class Tests
    {
        public PlantUMLParser Parser { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Parser = new PlantUMLParser();
        }

        [Test]
        public void Test1()
        {
            var parsedResponse = this.Parser.Parse(@$"@startuml
  Standing -> Ducking : Down
  Ducking -> Standing : Up
  Standing -> Jumping : Up2
  Jumping -> Diving : Down
@enduml
");
            Console.WriteLine(JsonConvert.SerializeObject(parsedResponse));
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            
        }
    }
}