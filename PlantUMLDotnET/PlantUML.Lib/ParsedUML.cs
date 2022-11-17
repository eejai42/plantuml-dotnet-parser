using plantumldotnetparser.Lib.DataClasses;

namespace PlantUML.Lib
{
    public class ParsedUML
    {
        public ParsedUML(string umlText)
        {
            UmlText = umlText;
            this.Lines = new List<String>();
            this.Instructions = new List<Instruction>();
        }

        public string UmlText { get; }
        public List<string> Lines { get; }
        public List<Instruction> Instructions { get; }
        public string Name { get; internal set; }

        internal void ParseLine(string line)
        {
            if (String.Equals(line, Keyword.startuml.KeywordText, StringComparison.OrdinalIgnoreCase))
            {

            } 
            else if (String.Equals(line, Keyword.startuml.KeywordText, StringComparison.OrdinalIgnoreCase)) { }
            else if (String.Equals(line, Keyword.enduml.KeywordText, StringComparison.OrdinalIgnoreCase)) { }
            else if (String.Equals(line, Keyword.title.KeywordText, StringComparison.OrdinalIgnoreCase)) { }
            else
            {
                this.Lines.Add(line);
                var instruction = new Instruction(line);                
                this.Instructions.Add(instruction);
            }
        }
    }
}