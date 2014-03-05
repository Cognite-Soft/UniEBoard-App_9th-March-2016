// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelperMethodExtensions.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains HtmlHelper Method Extensions
// </summary>
// ------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web;

namespace Cognite.Utility.MethodExtensions.HtmlExtensions
{
    /// <summary>
    /// HtmlHelper Method Extensions
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Validations the summary with container.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="message">The message.</param>
        /// <param name="cssclass">The cssclass.</param>
        /// <returns></returns>
        public static string ValidationSummaryWithContainer(this HtmlHelper htmlHelper, bool excludePropertyErrors, string cssClass, string clientIdentifier)
         {
            string idProperty = string.IsNullOrEmpty(clientIdentifier) ? "" : string.Format(" id='{0}'", clientIdentifier);
            string cssProperty = string.IsNullOrEmpty(cssClass) ? "" : string.Format(" class='{0}'", cssClass);
            string output = string.Empty;

            if (!htmlHelper.ViewData.ModelState.IsValid)
            {
                output = string.Format("<div{0}{1} data-alert=''>{2}</div>", idProperty, cssProperty, htmlHelper.ValidationSummary(excludePropertyErrors));
            }

            return output;
         }

        /// <summary>
        /// Validations the summary with container.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="message">The message.</param>
        /// <param name="cssclass">The cssclass.</param>
        /// <returns></returns>
        public static string ValidationSummaryWithContainer(this HtmlHelper htmlHelper, bool excludePropertyErrors)
         {
             return ValidationSummaryWithContainer(htmlHelper, excludePropertyErrors, string.Empty, string.Empty);
         }
    }
}
