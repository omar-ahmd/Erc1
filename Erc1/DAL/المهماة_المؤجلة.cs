//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Erc1.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class المهماة_المؤجلة
    {
        public int رمز { get; set; }
        public int رمز_المركز { get; set; }
        public Nullable<int> اسم { get; set; }
        public Nullable<int> العمر { get; set; }
        public Nullable<int> من_رمز_المدينة { get; set; }
        public Nullable<int> من_رمز_المنطقة { get; set; }
        public Nullable<int> من_مشفى { get; set; }
        public Nullable<int> من_القسم { get; set; }
        public Nullable<int> تفاصيل_ال_من { get; set; }
        public Nullable<int> إلى_مشفى { get; set; }
        public Nullable<int> إلى_القسم { get; set; }
        public Nullable<int> الى_رمز_المدينة { get; set; }
        public Nullable<int> الى_رمز_المنطقة { get; set; }
        public Nullable<int> تفاصيل_ال_الى { get; set; }
        public Nullable<int> رمز_الحالة { get; set; }
        public Nullable<System.DateTime> التاريخ_والوقت { get; set; }
    
        public virtual أقسام_المستشفيات أقسام_المستشفيات { get; set; }
        public virtual أقسام_المستشفيات أقسام_المستشفيات1 { get; set; }
        public virtual الحالات الحالات { get; set; }
        public virtual المدن المدن { get; set; }
        public virtual المدن المدن1 { get; set; }
        public virtual المستشفيات المستشفيات { get; set; }
        public virtual المستشفيات المستشفيات1 { get; set; }
        public virtual المناطق المناطق { get; set; }
        public virtual المناطق المناطق1 { get; set; }
    }
}
