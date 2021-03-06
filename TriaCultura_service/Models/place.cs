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

    public partial class place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public place(bool serialize)
        {
            this.place_has_capacity = new HashSet<place_has_capacity>();
            this.requests = new HashSet<request>();
            this.SerializeVirtualProperties = serialize;
        }
        public place()
        {
            this.place_has_capacity = new HashSet<place_has_capacity>();
            this.requests = new HashSet<request>();
        }

        public int id_place { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public string address { get; set; }

        [JsonIgnore]
        public bool SerializeVirtualProperties { get; set; }

        public bool ShouldSerializerequests()
        {
            return SerializeVirtualProperties;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<place_has_capacity> place_has_capacity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }
    }
}
