namespace PlantUML.Lib
{
    public class ParsedUML
    {
        public ParsedUML(string umlText)
        {
            UmlText = umlText;
        }

        public string UmlText { get; }
        public string Name { get; internal set; }
    }
}