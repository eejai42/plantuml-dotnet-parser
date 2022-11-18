/*************************************************
Initially Generated by SSoT.me - 2022
    EJ Alexandra - ssotme odxml42/odxml-to-csharp-pocos
    This be overwritten
*************************************************/
using System;
using System.ComponentModel;
                        
namespace plantumldotnetparser.Lib.DataClasses
{                   
    public partial class InstructionType
    {
        public static List<InstructionType> InstructionTypes { get; set; } = new List<InstructionType>();    

        private static InstructionType _Declaration = new InstructionType() {
            Name = "Declaration",
            KeywordText = "",
            RegEx = "(participant|actor)(.*)( as )(.*)"
        };
        public static InstructionType @Declaration { get { return _Declaration; } }
    
        private static InstructionType _LeftRightMessage = new InstructionType() {
            Name = "LeftRightMessage",
            KeywordText = "",
            RegEx = "([^-]*)(-?->)([^\:]*)"
        };
        public static InstructionType @LeftRightMessage { get { return _LeftRightMessage; } }
    
        private static InstructionType _StartUML = new InstructionType() {
            Name = "StartUML",
            KeywordText = "@startuml",
            RegEx = "@startuml"
        };
        public static InstructionType @StartUML { get { return _StartUML; } }
    
        private static InstructionType _EndUML = new InstructionType() {
            Name = "EndUML",
            KeywordText = "@enduml",
            RegEx = "@enduml"
        };
        public static InstructionType @EndUML { get { return _EndUML; } }
    
        private static InstructionType _Start = new InstructionType() {
            Name = "Start",
            KeywordText = "start",
            RegEx = "start"
        };
        public static InstructionType @Start { get { return _Start; } }
    
        private static InstructionType _Stop = new InstructionType() {
            Name = "Stop",
            KeywordText = "stop",
            RegEx = "stop"
        };
        public static InstructionType @Stop { get { return _Stop; } }
    
        private static InstructionType _Title = new InstructionType() {
            Name = "Title",
            KeywordText = "title",
            RegEx = "title"
        };
        public static InstructionType @Title { get { return _Title; } }
    
        private static InstructionType _As = new InstructionType() {
            Name = "As",
            KeywordText = "as",
            RegEx = "as"
        };
        public static InstructionType @As { get { return _As; } }
    
        static InstructionType()
        {

            InstructionTypes.Add(@Declaration);            

            InstructionTypes.Add(@LeftRightMessage);            

            InstructionTypes.Add(@StartUML);            

            InstructionTypes.Add(@EndUML);            

            InstructionTypes.Add(@Start);            

            InstructionTypes.Add(@Stop);            

            InstructionTypes.Add(@Title);            

            InstructionTypes.Add(@As);            
        
        }
    }
}