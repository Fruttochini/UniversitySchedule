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
    
    public partial class University_StudentPresence
    {
        public int LessonID { get; set; }
        public int StudentID { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Mark { get; set; }
        public bool Present { get; set; }
    
        public virtual University_Schedule University_Schedule { get; set; }
        public virtual University_Student University_Student { get; set; }
    }
}
