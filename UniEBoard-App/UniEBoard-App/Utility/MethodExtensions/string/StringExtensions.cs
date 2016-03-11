// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains String Method Extensions
// </summary>
// ------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web;

namespace Cognite.Utility.MethodExtensions.StringExtensions
{
    /// <summary>
    /// String Method Extensions
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        ///  Converts a string to a nullable integer.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static int? ToNullableInteger(this string item)
         {
             int? returnValue = null;
             try
             {
                 returnValue = int.Parse(item);
             }
             catch (Exception)
             {
                 returnValue = null;
             }
             return returnValue;
         }

        /// <summary>
        /// Converts a string to an integer.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static int ToInteger(this string item)
        {
            int returnValue = 0;
            try
            {
                returnValue = int.Parse(item);
            }
            catch (Exception)
            {
                returnValue = 0;
            }
            return returnValue;
        }
    }
}
