using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A helper for Expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>s the return value
        /// Compiles an expression and get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>s the return value
        /// Compiles an expression and get
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <typeparam name="In">The input to the expression</typeparam>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static T GetPropertyValue<In, T>(this Expression<Func<In, T>> lambda, In input)
        {
            return lambda.Compile().Invoke(input);
        }

        /// <summary>
        /// Sets the underline property value to the given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambda"></param>
        /// 
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            //Get the property Information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //Set the property of target object
            propertyInfo.SetValue(target, value);
        }

        /// <summary>
        /// Sets the underline property value to the given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <typeparam name="In">The input into the expression</typeparam>
        /// <param name="lambda"></param>
        /// 
        public static void SetPropertyValue<In, T>(this Expression<Func<In, T>> lambda, T value, In input)
        {
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            //Get the property Information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;

            //Set the property of target object
            propertyInfo.SetValue(input, value);
        }
    }
}
