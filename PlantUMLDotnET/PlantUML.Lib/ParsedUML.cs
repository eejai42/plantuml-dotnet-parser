using plantumldotnetparser.Lib.DataClasses;
using System;
using System.Collections.Generic;

namespace PlantUML.Lib
{
    public class ParsedUML
    {
        public ParsedUML()
        {
            this.UmlText = String.Empty;
            this.Lines = new List<String>();
            this.Instructions = new List<Instruction>();
        }
        public ParsedUML(string umlText): this()
        {
            UmlText = umlText;
        }

        public string UmlText { get; set; }
        public List<string> Lines { get; set; }
        public List<Instruction> Instructions { get; set; }
        public string Name { get; set; }

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