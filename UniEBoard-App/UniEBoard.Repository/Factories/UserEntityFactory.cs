// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserEntityFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AssetEntityFactory class definition
//  Contains methods to build Asset Entities
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public static class UserEntityFactory
    {
        #region Methods

        /// <summary>
        /// Creates the user entity.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static Model.Entities.User CreateFromDataModel(User user, IObjectMapperAdapter objectMapper)
        {
            if (user is Student)
            {
                return objectMapper.Map<Student, Model.Entities.Student>((Student)user);
            }
            else if (user is Staff)
            {
                return objectMapper.Map<Staff, Model.Entities.Staff>((Staff)user);
            }
            else
            {
                return objectMapper.Map<User, Model.Entities.User>(user);
            }
        }

        /// <summary>
        /// Creates from data model.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<Model.Entities.User> CreateFromDataModel(List<User> user, IObjectMapperAdapter objectMapper)
        {
            return user.Select(u => CreateFromDataModel(u, objectMapper)).ToList<Model.Entities.User>();
        }

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static Repository.User CreateFromDomainModel(Model.Entities.User user, IObjectMapperAdapter objectMapper)
        {
            if (user is Model.Entities.Student)
            {
                return objectMapper.Map<Model.Entities.Student, Student>((Model.Entities.Student)user);
            }
            else if (user is Model.Entities.Staff)
            {
                return objectMapper.Map<Model.Entities.Staff, Staff>((Model.Entities.Staff)user);
            }
            else
            {
                return objectMapper.Map<Model.Entities.User, User>(user);
            }
        }

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<User> CreateFromDomainModel(List<Model.Entities.User> user, IObjectMapperAdapter objectMapper)
        {
            return user.Select(u => CreateFromDomainModel(u, objectMapper)).ToList<User>();
        }

        
        #endregion
    }
}
