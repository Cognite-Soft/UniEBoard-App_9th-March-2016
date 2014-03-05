// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  FileFactory class definition
//  Contains methods to build different files
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using UniEBoard.Model.Entities;
using Cognite.Utility.MethodExtensions.HttpPostedFileExtensions;

namespace UniEBoard.Model.Factories
{
    public static class FileFactory
    {
        public static BaseFile CreateSubmissionContentFile(int submissionId, int assignmentId, HttpPostedFileBase httpPostedFileBase)
        {
            return httpPostedFileBase.ContentLength > 0 
            ?   new File()
                {
                    AssignmentId = assignmentId,
                    SubmissionId = submissionId,
                    Content = httpPostedFileBase.Bytes(),
                    Extension = httpPostedFileBase.FileExtension(),
                    FileName = httpPostedFileBase.FileNameFromPath(),
                    ContentType = httpPostedFileBase.ContentType,
                    ContentLength = httpPostedFileBase.ContentLength
                }
            :   null;
        }
    }
}
