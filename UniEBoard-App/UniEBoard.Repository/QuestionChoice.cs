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
    
    public partial class QuestionChoice
    {
        public QuestionChoice()
        {
            this.AnswerQuestionChoices = new HashSet<AnswerQuestionChoice>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public short PointsValue { get; set; }
        public short DisplayOrder { get; set; }
        public bool CorrectAnswer { get; set; }
        public int Question_Id { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual ICollection<AnswerQuestionChoice> AnswerQuestionChoices { get; set; }
    }
}
