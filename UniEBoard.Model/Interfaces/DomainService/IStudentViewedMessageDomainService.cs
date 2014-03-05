// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStudentViewedMessageDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for StudentViewedMessage Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IStudentViewedMessageDomainService Interface definition - Contains Methods for StudentViewedMessage Operations
    /// </summary>
    public interface IStudentViewedMessageDomainService : IBaseDomainService<ViewedMessage>
    {
    }
}
