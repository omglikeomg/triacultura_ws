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

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.ratings = new HashSet<rating>();
            this.votes = new HashSet<vote>();
        }
        public user(bool serialize)
        {
            this.ratings = new HashSet<rating>();
            this.votes = new HashSet<vote>();
            this.SerializeVirtualProperties = serialize;
        }
    
        public int id { get; set; }
        public string dni { get; set; }
        public string password { get; set; }

        [JsonIgnore]
        public bool SerializeVirtualProperties { get; set; }

        public bool ShouldSerializevotes ()
        {
            return SerializeVirtualProperties;
        }
        public bool ShouldSerializeratings ()
        {
            return SerializeVirtualProperties;
        }
    
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rating> ratings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vote> votes { get; set; }
    }
}
