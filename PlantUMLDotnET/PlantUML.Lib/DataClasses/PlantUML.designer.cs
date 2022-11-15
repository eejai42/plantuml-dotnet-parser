using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace plantumldotnetparser.Lib.DataClasses
{                            
    public partial class PlantUML
    {
        private void InitPoco()
        {
            
            this.PlantUMLId = Guid.NewGuid();
            

        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "PlantUMLId")]
        public Guid PlantUMLId { get; set; }
    

        

        
        
        private static string CreatePlantUMLWhere(IEnumerable<PlantUML> plantUMLs, String forignKeyFieldName = "PlantUMLId")
        {
            if (!plantUMLs.Any()) return "1=1";
            else 
            {
                var idList = plantUMLs.Select(selectPlantUML => String.Format("'{0}'", selectPlantUML.PlantUMLId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
