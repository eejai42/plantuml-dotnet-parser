using PlantUML.Lib;

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
            var parsedResposne = this.Parser.Parse(@$"@startuml
Alice -> Bob : Hello
@enduml
");
            Assert.Pass();
        }
    }
}