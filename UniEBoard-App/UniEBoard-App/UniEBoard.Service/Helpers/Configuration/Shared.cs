using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UniEBoard.Service.Helpers.Configuration
{
    public class Shared : ConfigurationBase
    {
        private static Shared current = new Shared();
        public static Shared Current { get { return current; } }

        public bool ValidateServerCertificate { get; protected set; }

        protected Shared()
        {
            ReadConfiguration();
        }

        public virtual void ReadConfiguration()
        {
            AppSettingsReader reader = new AppSettingsReader();
            ValidateServerCertificate = GetValueFromWebConfig<bool>(reader, "ValidateServerCertificate", false, true);
        }
    }
}
