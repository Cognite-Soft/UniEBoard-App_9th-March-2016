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
using System.Linq;
using System.Text;

namespace UniEBoard.Service
{
    public sealed class C
    {
        /// <summary>
        /// Cache Key Constants
        /// </summary>
        public class CacheKeys 
        {
            public const string LoginTypes = "logintypescachekey";
            public const string GenderTypes = "gendertypescachekey";
            public const string MessageTypes = "messagetypescachekey";
        }

        public class Roles
        {
            public const string Administrator = "Administrator";
            public const string Teacher = "Teacher";
            public const string Student = "Student";
        }

        public const string SessionKeyWebUser = "UniEBoard.Service.Models.UserViewModel";
        //public const string SessionKeySystemUser = "Cognite.DACS.CRMInterface.Client.SystemUser";
    }
}