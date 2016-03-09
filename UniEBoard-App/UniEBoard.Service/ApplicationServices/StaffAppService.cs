// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Staff Application Service Operations
//  Transforms entity domain models to view models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Staff Application Service Class - Contains Methods for Staff Application Service Operations
    /// </summary>
    public class StaffAppService : BaseAppService, IStaffAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the staff manager.
        /// </summary>
        /// <value>The staff manager.</value>
        public IStaffDomainService StaffManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffAppService"/> class.
        /// </summary>
        /// <param name="staffManager">The staff manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        public StaffAppService(
            IStaffDomainService staffManager, 
            IObjectMapperAdapter objectMapper, 
            ICacheAdapter cacheService, 
            IExceptionManagerAdapter exceptionManager, 
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.StaffManager = staffManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all the staff.
        /// </summary>
        /// <returns></returns>
        public List<StaffViewModel> GetAllStaff()
        {

            List<StaffViewModel> models = new List<StaffViewModel>();
            try
            {
                List<Staff> staff = StaffManager.FindAll();
                models = ObjectMapper.Map<Model.Entities.Staff, StaffViewModel>(staff);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the staff by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        public StaffViewModel GetStaffByMemberShipId(int membershipId)
        {
            StaffViewModel model = default(StaffViewModel);
            try
            {
                Staff staff = StaffManager.GetStaffByMemberShipId(membershipId);
                model = ObjectMapper.Map<Model.Entities.Staff, StaffViewModel>(staff);
            }
            catch (Exception ex)
            {
                 ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Creates the staff user.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="model">The model.</param>
        public void CreateStaffUser(int membershipId, StaffViewModel model)
        {
            try
            {
                Staff user = ObjectMapper.Map<StaffViewModel, Model.Entities.Staff>(model);
                user.Membership_Id = membershipId;
                StaffManager.Add(user);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Creates the staff user.
        /// </summary>
        /// <typeparam name="TRegisterStaffViewModel">The type of the register staff view model.</typeparam>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="model">The model.</param>
        public StaffViewModel GetStaffByUserName(string username)
        {
            StaffViewModel model = GetAllStaff().Where(s => s.UserName.ToLower().Equals(username.ToLower())).FirstOrDefault();
            return model;
        }

        #endregion
    }
}
