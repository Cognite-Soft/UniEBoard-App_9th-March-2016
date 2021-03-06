//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniEBoard.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Submission
    {
        public Submission()
        {
            this.FileUploads = new HashSet<BaseFile>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string DateSubmitted { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public Nullable<int> GradePointValue { get; set; }
    
        public virtual Assignment Assignment { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<BaseFile> FileUploads { get; set; }
    }
}
