﻿namespace LinqToQuerystring.TreeNodes.Functions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class ToLowerNode : SingleChildNode
    {
        public ToLowerNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var childexpression = this.ChildNode.BuildLinqExpression(query, expression, item);

            if (!childexpression.Type.IsAssignableFrom(typeof(string)))
            {
                childexpression = Expression.Convert(childexpression, typeof(string));
            }

            return Expression.Call(childexpression, "ToLower", null, null);
        }
    }
}