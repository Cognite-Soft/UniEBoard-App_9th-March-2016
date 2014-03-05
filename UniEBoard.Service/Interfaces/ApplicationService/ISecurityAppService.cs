// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISecurityAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//   Contains Interface Methods for Security Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// SecurityAppService Service Interface - Contains Methods for Security Service Operations
    /// </summary>
    public interface ISecurityAppService : IBaseAppService
    {
        /// <summary>
        /// Gets the section roles.
        /// </summary>
        /// <param name="controllername">The controllername.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        string GetSectionRoles(string controllername, string actionName = "Index");
    }
}
