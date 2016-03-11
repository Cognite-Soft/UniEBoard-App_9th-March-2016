// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyAssociationBuilder.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  PropertyAssociationBuilder class definition
//  Builds association lists for Eager loading
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UniEBoard.Model.Builders
{
    public class PropertyAssociationBuilder<TModel>
        where TModel : C.NavigationalProperties.BaseNavigationalProperty, new()
    {
        /// <summary>
        /// The property association expressions array
        /// </summary>
        private Expression<Func<TModel, string>>[] _associationExpressions;
        
        /// <summary>
        /// The Model instance containing association properties
        /// </summary>
        private TModel _model;

        /// <summary>
        /// Gets the model instance.
        /// </summary>
        /// <value>The model instance.</value>
        public TModel ModelInstance
        {
            get { return _model ?? (_model = new TModel()); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAssociationBuilder&lt;TModel, TValue&gt;"/> class.
        /// </summary>
        /// <param name="associationExpressions">The association expressions.</param>
        public PropertyAssociationBuilder(params Expression<Func<TModel, string>>[] associationExpressions)
        {
            _associationExpressions = associationExpressions;
        }

        /// <summary>
        /// Gets the expression string value for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="expressionValue">The expression value.</param>
        /// <returns></returns>
        private string GetExpressionStringValueFor(Expression<Func<TModel, string>> expressionValue)
        {
            try
            {
                return expressionValue.Compile().Invoke(ModelInstance) as string;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Builds the association.
        /// </summary>
        /// <returns></returns>
        public List<string> BuildAssociation()
        {
            var associationList = new List<string>();
            associationList.AddRange(_associationExpressions.Select(GetExpressionStringValueFor));
            return associationList;
        }
    }
}
