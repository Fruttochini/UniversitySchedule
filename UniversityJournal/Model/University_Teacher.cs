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
    
    public partial class University_Teacher
    {
        public University_Teacher()
        {
            this.University_Schedule = new HashSet<University_Schedule>();
            this.University_Subject = new HashSet<University_Subject>();
        }
    
        public int Teacher_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public System.DateTime Birthday { get; set; }
        public byte[] Photo { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<University_Schedule> University_Schedule { get; set; }
        public virtual ICollection<University_Subject> University_Subject { get; set; }
    }
}