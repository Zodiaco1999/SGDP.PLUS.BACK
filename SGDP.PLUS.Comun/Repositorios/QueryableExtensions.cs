﻿using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace SGDP.PLUS.Comun.Repositorios
{
    public static class QueryableExtensions
    {
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly PropertyInfo NodeTypeProviderField = QueryCompilerTypeInfo.DeclaredProperties.Single(x => x.Name == "NodeTypeProvider");

        private static readonly MethodInfo CreateQueryParserMethod = QueryCompilerTypeInfo.DeclaredMethods.First(x => x.Name == "CreateQueryParser");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly FieldInfo QueryCompilationContextFactoryField = typeof(Database).GetTypeInfo().DeclaredFields.Single(x => x.Name == "_queryCompilationContextFactory");

        //public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        //{
        //    if (!(query is EntityQueryable<TEntity>) && !(query is InternalDbSet<TEntity>))
        //    {
        //        throw new ArgumentException("Invalid query");
        //    }

        //    var queryCompiler = (IQueryCompiler)QueryCompilerField.GetValue(query.Provider);
        //    var nodeTypeProvider = (INodeTypeProvider)NodeTypeProviderField.GetValue(queryCompiler);
        //    var parser = (IQueryParser)CreateQueryParserMethod.Invoke(queryCompiler, new object[] { nodeTypeProvider });
        //    var queryModel = parser.GetParsedQuery(query.Expression);
        //    var database = DataBaseField.GetValue(queryCompiler);
        //    var queryCompilationContextFactory = (IQueryCompilationContextFactory)QueryCompilationContextFactoryField.GetValue(database);
        //    var queryCompilationContext = queryCompilationContextFactory.Create(false);
        //    var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
        //    modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
        //    var sql = modelVisitor.Queries.First().ToString();

        //    return sql;
        //}

        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            if (!(query is EntityQueryable<TEntity>) && !(query is InternalDbSet<TEntity>))
            {
                throw new ArgumentException("Invalid query");
            }

            var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression).GetEnumerator();
            var enumeratorType = enumerator.GetType();
            var selectFieldInfo = enumeratorType.GetField("_selectExpression", BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new InvalidOperationException($"cannot find field _selectExpression on type {enumeratorType.Name}");
            var sqlGeneratorFieldInfo = enumeratorType.GetField("_querySqlGeneratorFactory", BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new InvalidOperationException($"cannot find field _querySqlGeneratorFactory on type {enumeratorType.Name}");
            var selectExpression = selectFieldInfo.GetValue(enumerator) as SelectExpression ?? throw new InvalidOperationException($"could not get SelectExpression");
            var factory = sqlGeneratorFieldInfo.GetValue(enumerator) as IQuerySqlGeneratorFactory ?? throw new InvalidOperationException($"could not get IQuerySqlGeneratorFactory");
            var sqlGenerator = factory.Create();
            var command = sqlGenerator.GetCommand(selectExpression);
            var sql = command.CommandText;
            return sql;
        }
    }
}
