// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Task Operations
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
    /// ITaskDomainService Interface definition - Contains Methods for Task Operations
    /// </summary>
    public interface IVideoDomainService : IBaseDomainService<Video>
    {

        Model.Entities.Video FindVideoById(int id);
    }
}
