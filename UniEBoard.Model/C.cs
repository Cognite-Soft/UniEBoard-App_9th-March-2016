// --------------------------------------------------------------------------------------------------------------------
// <copyright file="C.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Property Constansts
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Cognite.Utility.Attributes;


namespace UniEBoard.Model
{
    public sealed class C
    {
        /// <summary>
        /// The DBContext Navigational Property Names
        /// </summary>
        public class NavigationalProperties
        {
            public class BaseNavigationalProperty
            {               
            }

            /// <summary>
            /// User Navigational Entity Property Association Names
            /// </summary>
            public class User : BaseNavigationalProperty
            {
                public string Groups = "Groups";
                public string Permissions = "Permissions";
                public string Tasks = "Tasks"; 
            }

            /// <summary>
            /// Student Navigational Entity Property Association Names
            /// </summary>
            public class Student : User
            {
                public string CourseRegistrations = "CourseRegistrations";
                public string Alerts = "Alerts";
                public string Submissions = "Submissions";
                public string QuizEntries = "QuizEntries";
                public string AlertsAndViews = "Alerts.StudentViewedAlerts";
                public string GroupAlertsAndViews = "Groups.Alerts.StudentViewedAlerts";
                public string CourseModules = "CourseRegistrations.Course.CourseModules.Module";
            }

            /// <summary>
            /// Staff Navigational Entity Property Association Names
            /// </summary>
            public class Staff : User
            {
                public string Department = "Department";
                public string StaffCourses = "StaffCourses";
                public string Modules = "Modules";
                public string Units = "Units";
                public string Alerts = "Alerts";
            }


            //BuildAssociation<Staff>(instance.Department,instance.StaffCourses, instance.Modules)

            /// <summary>
            /// Group Navigational Entity Property Association Names
            /// </summary>
            public class Group : BaseNavigationalProperty
            {
                public string Users = "Users";
            }

            /// <summary>
            /// Membership Navigational Entity Property Association Names
            /// </summary>
            public class Membership : BaseNavigationalProperty
            {
                public string User = "User";
            }

            /// <summary>
            /// Message Navigational Entity Property Association Names
            /// </summary>
            public class Message : BaseNavigationalProperty
            {
                public string FromUser = "FromUser";
                public string RecipientUser = "RecipientUser";
                public string Group = "Group";
                public string ViewedMessages = "ViewedMessages";
            }

            /// <summary>
            /// Schedule Navigational Entity Property Association Names
            /// </summary>
            public class Schedule : BaseNavigationalProperty
            {
                public string Course = "Course";
                public string Unit = "Unit";
                public string UnitAndModule = "Unit.Module";
            }

            /// <summary>
            /// Course Navigational Entity Property Association Names
            /// </summary>
            public class Course : BaseNavigationalProperty
            {
                public string CourseModules = "CourseModules";
                public string Modules = "CourseModules.Module";
            }
        }

        /// <summary>
        /// The exception policy properties
        /// </summary>
        public class ExceptionPolicy
        {
            /// <summary>
            /// Exception Policy Names
            /// </summary>
            public class Names
            {
                public const string ExceptionShielding = "ExceptionShielding";
                public const string ExceptionReplacing = "ExceptionReplacing";
            }
        }
    }
}
