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
    
    public partial class Quiz
    {
        public Quiz()
        {
            this.Assignments = new HashSet<Assignment>();
            this.Questions = new HashSet<Question>();
            this.QuizEntries = new HashSet<QuizEntry>();
            this.ModuleQuizs = new HashSet<ModuleQuiz>();
            this.Units = new HashSet<Unit>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime PublishFrom { get; set; }
        public System.DateTime PublishTo { get; set; }
        public Nullable<int> MaxAttemptsAllowed { get; set; }
        public string Description { get; set; }
        public int DisplayEndResults { get; set; }
        public bool CorrectUserChoices { get; set; }
        public string Instructions { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
    
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<QuizEntry> QuizEntries { get; set; }
        public virtual ICollection<ModuleQuiz> ModuleQuizs { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
