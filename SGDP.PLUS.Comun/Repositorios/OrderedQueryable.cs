using Microsoft.EntityFrameworkCore.Infrastructure;
using SGDP.PLUS.Comun.Excepcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGDP.PLUS.Comun.Repositorios
{
    public static class OrderedQueryable
    {
        public static IOrderedQueryable<T> ApplyOrder<T>(this IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop);
                if (pi == null)
                    pi = type.GetProperties().FirstOrDefault(x => x.Name.ToLower() == prop.ToLower());
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                && method.IsGenericMethodDefinition
                && method.GetGenericArguments().Length == 2
                && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }

        public static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            string command = (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty);
            var properties = propertyName.Split(".");
            var parameter = Expression.Parameter(typeof(T), "p");
            PropertyInfo? property = null;
            MemberExpression? propertyAccess = null;
            var orderByExpression = source.Expression;
            var typeArguments = new Type[] { };

            foreach (var prop in properties)
            {
                propertyName = prop;
                var type = property == null ? typeof(T) : property.PropertyType;
                property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (property == null) 
                    throw new ValidationException($"No se pudo ordenar por el campo {propertyName}, por favor contacte a soporte");
     
                Expression parameterExpression = propertyAccess == null ? parameter : propertyAccess;
                propertyAccess = Expression.MakeMemberAccess(parameterExpression, property);
                orderByExpression = Expression.Lambda(propertyAccess, parameter);
                typeArguments = new Type[] { typeof(T), propertyAccess.Type };
            }

            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                command,
                typeArguments,
                source.Expression,
                Expression.Quote(orderByExpression));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, false);
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, false);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, true);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, true);
        }
    }
}
