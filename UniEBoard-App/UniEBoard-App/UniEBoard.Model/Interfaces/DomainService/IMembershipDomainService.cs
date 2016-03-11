// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMembershipDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Membership Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IMembershipDomainService Interface definition - Contains Methods for membership Operations
    /// </summary>
    public interface IMembershipDomainService : IBaseDomainService<Membership>
    {
    }
}
