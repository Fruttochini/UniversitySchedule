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
    
    public partial class University_Group
    {
        public University_Group()
        {
            this.University_Schedule = new HashSet<University_Schedule>();
            this.University_Subject = new HashSet<University_Subject>();
            this.University_Student = new HashSet<University_Student>();
        }
    
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
    
        public virtual ICollection<University_Schedule> University_Schedule { get; set; }
        public virtual ICollection<University_Subject> University_Subject { get; set; }
        public virtual ICollection<University_Student> University_Student { get; set; }
    }
}