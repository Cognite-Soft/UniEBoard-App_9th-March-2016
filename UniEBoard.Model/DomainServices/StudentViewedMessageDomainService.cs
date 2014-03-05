// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentViewedMessageDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for StudentViewedMessage Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// StudentViewedMessageDomainService class definition - Contains Methods for StudentViewedMessage Operations
    /// </summary>
    public class StudentViewedMessageDomainService : BaseDomainService<ViewedMessage, IViewedMessageRepository>, IStudentViewedMessageDomainService
    {
        #region Properties

        /// <summary>
        /// StudentViewedAlertRepository Instance
        /// </summary>
        public IViewedMessageRepository StudentViewedAlertRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentViewedMessageDomainService"/> class.
        /// </summary>
        /// <param name="alertRepository">The studentViewedAlert repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public StudentViewedMessageDomainService(IViewedMessageRepository studentViewedAlertRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(studentViewedAlertRepository, exceptionManager, loggingService)
        {
            StudentViewedAlertRepository = studentViewedAlertRepository;
        }

        #endregion
    }
}
