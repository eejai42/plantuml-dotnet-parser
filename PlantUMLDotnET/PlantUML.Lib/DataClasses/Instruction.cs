/*************************************************
Initially Generated by SSoT.me - 2017
    EJ Alexandra - ssotme odxml42/odxml-to-csharp-pocos
    This file WILL NOT be overwritten once changes are made.
*************************************************/
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace plantumldotnetparser.Lib.DataClasses
{                   
    
    public partial class Instruction 
    {
        public Instruction()
        {
            this.InitPoco();
        }

        public Instruction(string line)
        {
            line = $"{line}";
            var firstWord = line.Substring(0, $"{line} ".IndexOf(" "));
            var keyword = DataClasses.InstructionType
                                        .InstructionTypes
                                        .OrderBy(instructionType => instructionType.SortOrder)
                                        .FirstOrDefault(fod => Regex.IsMatch(line, fod.RegEx));
            if (keyword == DataClasses.InstructionType.LeftRightMessage)
            {
                var matchList = Regex.Matches(line, keyword.RegEx).OfType<Match>().ToList();
                var firstMatch = matchList.FirstOrDefault();
                if (firstMatch is null) { }
                else
                {
                    this.Name = this.LeftRightInstructionText = line;
                    this.LeftParticipantName = $"{firstMatch.Groups[1]}";
                    this.Sequence = $"{firstMatch.Groups[2]}".Trim();
                    this.RightParticipantName = $"{firstMatch.Groups[3]}".Trim();
                    this.AdditionalText = $"{firstMatch.Groups[5]}".Trim();
                }
            }

            object o = 1;
        }

        public override String ToString()
        {
            return String.Format("Instruction: {0}", this.Name);
        }
                            
    }
}