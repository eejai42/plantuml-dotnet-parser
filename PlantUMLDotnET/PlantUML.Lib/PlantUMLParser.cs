namespace PlantUML.Lib
{
    public class PlantUMLParser
    {
        public PlantUMLParser()
        {
        }

        public ParsedUML Parse(string umlText)
        {
            return new ParsedUML(umlText)
            {
                Name = "foo"
            };
        }
    }
}