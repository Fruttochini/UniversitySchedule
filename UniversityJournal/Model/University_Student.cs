//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversityJournal.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class University_Student
    {
        public University_Student()
        {
            this.University_StudentPresence = new HashSet<University_StudentPresence>();
            this.University_Group = new HashSet<University_Group>();
        }
    
        public int Student_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public System.DateTime Birthday { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual ICollection<University_StudentPresence> University_StudentPresence { get; set; }
        public virtual ICollection<University_Group> University_Group { get; set; }
    }
}
