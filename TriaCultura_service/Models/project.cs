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

    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            this.files = new HashSet<file>();
            this.ratings = new HashSet<rating>();
            this.requests = new HashSet<request>();
            this.votes = new HashSet<vote>();
        }
        public project(bool serialize)
        {
            this.files = new HashSet<file>();
            this.ratings = new HashSet<rating>();
            this.requests = new HashSet<request>();
            this.votes = new HashSet<vote>();
            this.SerializeVirtualProperties = serialize;
        }

        [JsonIgnore]
        public bool SerializeVirtualProperties { get; set; }

        public bool ShouldSerializefiles()
        {
            return SerializeVirtualProperties;
        }

        public bool ShouldSerializevotes()
        {
            return SerializeVirtualProperties;
        }
        public bool ShouldSerializerequests()
        {
            return SerializeVirtualProperties;
        }
        public bool ShouldSerializeratings()
        {
            return SerializeVirtualProperties;
        }


        public int id_project { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string topic { get; set; }
        public string author_dni { get; set; }
        public string type { get; set; }
    
        public virtual author author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<file> files { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rating> ratings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vote> votes { get; set; }
    }
}
