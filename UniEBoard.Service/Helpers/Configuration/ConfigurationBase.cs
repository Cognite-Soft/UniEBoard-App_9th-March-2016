using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UniEBoard.Service.Helpers.Configuration
{
    public abstract class ConfigurationBase
    {
        protected T GetValueFromWebConfig<T>(AppSettingsReader reader, string key, bool required, T defaultValue)
        {
            try
            {
                return (T)reader.GetValue(key, typeof(T));
            }
            catch (Exception)
            {
                if (required)
                {
                    throw new Exception(string.Format("Value ({0}) is missing or in the wrong format", key));
                }
                else
                {
                    return defaultValue;
                }
            }
        }

    }
}
