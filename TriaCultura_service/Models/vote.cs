//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TriaCultura_service.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class vote
    {
        public vote()
        {

        }

        public vote(bool serialize)
        {
            this.SerializeVirtualProperties = serialize;
        }
        public int id_vote { get; set; }
        public System.DateTime date { get; set; }
        public int project_id { get; set; }
        public int user_id { get; set; }

        public virtual project project { get; set; }
        public virtual user user { get; set; }
        [JsonIgnore]
        public bool SerializeVirtualProperties { get; set; }

        public bool ShouldSerializeuser()
        {
            return SerializeVirtualProperties;
        }
        public bool ShouldSerializeproject()
        {
            return SerializeVirtualProperties;
        }
    }
}
