﻿namespace LinqToQuerystring.TreeNodes.Functions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class EndsWithNode : TwoChildNode
    {
        public EndsWithNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var leftExpression = this.LeftNode.BuildLinqExpression(query, expression, item);
            var rightExpression = this.RightNode.BuildLinqExpression(query, expression, item);

            if (!leftExpression.Type.IsAssignableFrom(typeof(string)))
            {
                leftExpression = Expression.Convert(leftExpression, typeof(string));
            }

            if (!rightExpression.Type.IsAssignableFrom(typeof(string)))
            {
                rightExpression = Expression.Convert(rightExpression, typeof(string));
            }

            return Expression.Call(leftExpression, "EndsWith", null, new[] { rightExpression });
        }
    }
}