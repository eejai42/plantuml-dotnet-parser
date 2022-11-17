using System;
using System.Linq;

namespace PlantUML.Lib
{
    public class PlantUMLParser
    {
        public PlantUMLParser()
        {
        }

        public ParsedUML Parse(string umlText)
        {
            var result = new ParsedUML(umlText);
            var lines = $"{umlText}".Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(line => $"{line}".Trim())
                        .ToList();
            lines.ForEach(line => result.ParseLine(line));
            return result;            
        }
    }
}