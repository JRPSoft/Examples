using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace teste_web_api.Models
{
    public class ValuesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("value")]
        public string BusinessValue { get; set; }
        
        [JsonProperty("other_value")]
        public int OtherBussinessValue { get; set; }

        public override bool Equals(Object other)
        {
            if (other == null) { return false; }
            if (object.ReferenceEquals(this, other)) { return true; }
            if((other as ValuesModel) == null){return false;}
            return this.Id == (other as ValuesModel).Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }


    }
}
