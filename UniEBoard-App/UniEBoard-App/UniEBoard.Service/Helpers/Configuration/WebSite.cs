using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace UniEBoard.Service.Helpers.Configuration
{
    public class WebSite : Shared
    {
        private static WebSite current = new WebSite();

        public static WebSite Current { get { return current; } }

        public string SMTPUserName { get; protected set; }
        public string SMTPPassword { get; protected set; }
        public string SMTPServer { get; protected set; }
        public int SMTPPort { get; protected set; }
        public bool SMTPEnableSSL { get; protected set; }
        public string EmailSenderEmailAddress { get; protected set; }
        public string SubjectResetPassword { get; protected set; }
        public string SubjectRegister { get; protected set; }

        public string TitleTeacher { get; protected set; }
        public string TitleStudent { get; protected set; }
        public string TitleCourse { get; protected set; }
        public string TitleModule { get; protected set; }
        public string TitleClass { get; protected set; }

        public string TitleTeachers
        {
            get
            {
                return string.Format("{0}{1}", TitleTeacher, "s");
            }
        }
        public string TitleStudents
        {
            get
            {
                return string.Format("{0}{1}", TitleStudent, "s");
            }
        }
        public string TitleCourses
        {
            get
            {
                return string.Format("{0}{1}", TitleCourse, "s");
            }
        }
        public string TitleModules
        {
            get
            {
                return string.Format("{0}{1}", TitleModule, "s");
            }
        }
        public string TitleClasses
        {
            get
            {
                if (TitleClass.ToLower().Equals("class")) 
                    return string.Format("{0}{1}", TitleClass, "es");
                else 
                    return string.Format("{0}{1}", TitleClass, "s");
            }
        }

        private WebSite()
        {
            ReadConfiguration();
        }

        public override void ReadConfiguration()
        {
            base.ReadConfiguration();
            AppSettingsReader reader = new AppSettingsReader();
            SMTPUserName = GetValueFromWebConfig<string>(reader, "SMTPUserName", false, null);
            SMTPPassword = GetValueFromWebConfig<string>(reader, "SMTPPassword", false, null);
            SMTPServer = GetValueFromWebConfig<string>(reader, "SMTPServer", true, null);
            SMTPPort = GetValueFromWebConfig<int>(reader, "SMTPPort", false, 25);
            SMTPEnableSSL = GetValueFromWebConfig<bool>(reader, "SMTPEnableSSL", false, false);
            EmailSenderEmailAddress = GetValueFromWebConfig<string>(reader, "EmailSenderEmailAddress", true, null);
            SubjectResetPassword = GetValueFromWebConfig<string>(reader, "SubjectResetPassword", true, null);
            SubjectRegister = GetValueFromWebConfig<string>(reader, "SubjectRegister", true, null);

            TitleTeacher = GetValueFromWebConfig<string>(reader, "TitleTeacher", false, "Teacher");
            TitleStudent = GetValueFromWebConfig<string>(reader, "TitleStudent", false, "Student");
            TitleCourse = GetValueFromWebConfig<string>(reader, "TitleCourse", false, "Course");
            TitleModule = GetValueFromWebConfig<string>(reader, "TitleModule", false, "Module");
            TitleClass = GetValueFromWebConfig<string>(reader, "TitleClass", false, "Class");
        }
    }
}
