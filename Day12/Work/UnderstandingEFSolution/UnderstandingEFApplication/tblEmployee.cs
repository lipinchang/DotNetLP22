//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnderstandingEFApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmployee()
        {
            this.tblEmployeeSalaries = new HashSet<tblEmployeeSalary>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> age { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployeeSalary> tblEmployeeSalaries { get; set; }
    }
}