// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageNavigationalProperty.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  MessageNavigationalProperty Enum Type
//  Used to specify message entity associations for eager loading
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// Message Navigational Property Types
    /// </summary>
    public enum MessageNavigationalProperty
    {
        FromUser,
        RecipientUser,
        Group,
        ViewedMessages
    }
}
