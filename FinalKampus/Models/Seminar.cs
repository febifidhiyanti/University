//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalKampus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seminar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seminar()
        {
            this.Mahasiswas = new HashSet<Mahasiswa>();
        }
    
        public int seminar_id { get; set; }
        public string seminar_nama { get; set; }
        public string seminar_dosen { get; set; }
        public string seminar_topik { get; set; }
        public string seminar_harga { get; set; }
        public Nullable<System.DateTime> seminar_tanggal { get; set; }
        public string seminar_ket { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mahasiswa> Mahasiswas { get; set; }
    }
}
