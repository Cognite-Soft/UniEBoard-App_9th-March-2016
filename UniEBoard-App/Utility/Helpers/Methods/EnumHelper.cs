// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumHelper.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Enum Helper methods
// </summary>
// ------------------------------------------------------------------------------------------------------------------

using Cognite.Utility.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection;

namespace Cognite.Utility.Helpers.Methods
{
    /// <summary>
    /// Enum Helper class
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Returns a dictionary containing all values of an enumeration type
        /// </summary>
        /// <typeparam name="TEnumType">The type of the enum type.</typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> DictionaryOf<TEnumType>()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            Type enumType = typeof(TEnumType);
            if (enumType.IsEnum)
            {
                foreach(FieldInfo field in enumType.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public))  
                {  
                    int value = (int)field.GetValue(null); 
                    string display = Enum.GetName(enumType, value);  
                    foreach(Attribute currAttr in field.GetCustomAttributes(true))  
                    {
                        DisplayAsAttribute valueAttribute = currAttr as DisplayAsAttribute;  
                        if (valueAttribute != null)  
                            display = valueAttribute.Name;  
                    }  
                    dictionary.Add(value, display);  
                }     
            }
            return dictionary;
        }

        /// <summary>
        /// Returns a string description for the enum
        /// </summary>
        /// <typeparam name="TEnumType">The enum value.</typeparam>
        /// <returns></returns>
        public static string DiscriptionFor(Enum value)
        {
            string display = Enum.GetName(value.GetType(), value);
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field != null)
            {
                foreach (Attribute currAttr in field.GetCustomAttributes(true))
                {
                    DisplayAsAttribute valueAttribute = currAttr as DisplayAsAttribute;
                    if (valueAttribute != null)
                        display = valueAttribute.Name;
                }
            }
            return display;
        }
    }
}
