// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRoleAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for  roles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UniEBoard.Model.Interfaces.Adapter
{
    /// <summary>
    /// The Role Provider Interface
    /// </summary>
    public interface IRoleAdapter
    {
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        void CreateRole(string roleName);

        /// <summary>
        /// Adds the user to role.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="roleName">Name of the role.</param>
        void AddUserToRole(string userName, string roleName);
    }
}
