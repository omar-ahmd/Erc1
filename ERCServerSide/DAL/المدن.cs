//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERCServerSide.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class المدن
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public المدن()
        {
            this.الأطباء = new HashSet<الأطباء>();
            this.العاملون = new HashSet<العاملون>();
            this.المراكز = new HashSet<المراكز>();
            this.المرضى = new HashSet<المرضى>();
            this.المستشفيات = new HashSet<المستشفيات>();
            this.المناطق = new HashSet<المناطق>();
            this.المهمات_الملغاة = new HashSet<المهمات_الملغاة>();
            this.المهمات_الملغاة1 = new HashSet<المهمات_الملغاة>();
            this.المهمات_المنفذة = new HashSet<المهمات_المنفذة>();
            this.المهمات_المنفذة1 = new HashSet<المهمات_المنفذة>();
            this.المهماة_المؤجلة = new HashSet<المهماة_المؤجلة>();
            this.المهماة_المؤجلة1 = new HashSet<المهماة_المؤجلة>();
        }
    
        public int رمز { get; set; }
        public string المدينة { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<الأطباء> الأطباء { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<العاملون> العاملون { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المراكز> المراكز { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المرضى> المرضى { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المستشفيات> المستشفيات { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المناطق> المناطق { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المهمات_الملغاة> المهمات_الملغاة { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المهمات_الملغاة> المهمات_الملغاة1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المهمات_المنفذة> المهمات_المنفذة { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المهمات_المنفذة> المهمات_المنفذة1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المهماة_المؤجلة> المهماة_المؤجلة { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<المهماة_المؤجلة> المهماة_المؤجلة1 { get; set; }
    }
}
