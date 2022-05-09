using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace NYCTaxiFHVData.Repository
{
    public class Repository : IRepository
    {


        /// <summary>
        /// Method to query data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="lazyLoad"></param>
        /// <param name="commandType"></param>
        /// <param name="transformResultSelector"></param>
        /// <returns></returns>
        /// <remarks>
        /// <see cref="transformResultSelector"/> is only used when lazy loading is disabled i.e. <see cref="lazyLoad"/> is set to false.
        /// If lazy loading is enabled then <see cref="transformResultSelector"/> would not be used and ignored.
        /// </remarks>
        /// 
        private string connectionString;
        public Repository()
        {
            connectionString=ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
                }
        }
public IQueryable<T> SqlQuery<T>(string query, IDictionary<string, object> parameters = null, bool lazyLoad = true, CommandType commandType = CommandType.Text, Func<dynamic, T> transformResultSelector = null) where T : class
        {
           
            return SqlQueryByDapper(query, parameters, commandType, transformResultSelector).AsQueryable();
        }

        public IEnumerable<T> SqlQueryValueType<T>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, Func<dynamic, T> transformResultSelector = null)
        {
            return SqlQueryByDapper(query, parameters, commandType, transformResultSelector);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> SqlQueryMultiple<T1, T2>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            return SqlQueryMultipleByDapper(query, parameters, commandType,
                resultSets =>
                {
                    var first = resultSets.Read<T1>().AsQueryable();
                    var second = resultSets.Read<T2>().AsQueryable();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(first, second);
                }) as Tuple<IEnumerable<T1>, IEnumerable<T2>>;
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> SqlQueryMultiple<T1, T2, T3>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            return SqlQueryMultipleByDapper(query, parameters, commandType,
                resultSets =>
                {
                    var first = resultSets.Read<T1>().AsQueryable();
                    var second = resultSets.Read<T2>().AsQueryable();
                    var third = resultSets.Read<T3>().AsQueryable();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(first, second, third);
                }) as Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>;
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> SqlQueryMultiple<T1, T2, T3, T4>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            return SqlQueryMultipleByDapper(query, parameters, commandType,
                resultSets =>
                {
                    var first = resultSets.Read<T1>().AsQueryable();
                    var second = resultSets.Read<T2>().AsQueryable();
                    var third = resultSets.Read<T3>().AsQueryable();
                    var fourth = resultSets.Read<T4>().AsQueryable();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(first, second, third, fourth);
                }) as Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>;
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> SqlQueryMultiple<T1, T2, T3, T4, T5>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            return SqlQueryMultipleByDapper(query, parameters, commandType,
                resultSets =>
                {
                    var first = resultSets.Read<T1>().AsQueryable();
                    var second = resultSets.Read<T2>().AsQueryable();
                    var third = resultSets.Read<T3>().AsQueryable();
                    var fourth = resultSets.Read<T4>().AsQueryable();
                    var fifth = resultSets.Read<T5>().AsQueryable();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(first, second, third, fourth, fifth);
                }) as Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>;
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> SqlQueryMultiple<T1, T2, T3, T4, T5, T6>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            return SqlQueryMultipleByDapper(query, parameters, commandType,
                resultSets =>
                {
                    var first = resultSets.Read<T1>().AsQueryable();
                    var second = resultSets.Read<T2>().AsQueryable();
                    var third = resultSets.Read<T3>().AsQueryable();
                    var fourth = resultSets.Read<T4>().AsQueryable();
                    var fifth = resultSets.Read<T5>().AsQueryable();
                    var sixth = resultSets.Read<T6>().AsQueryable();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(first, second, third, fourth, fifth, sixth);
                }) as Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>;
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> SqlQueryMultiple<T1, T2, T3, T4, T5, T6, T7>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            return SqlQueryMultipleByDapper(query, parameters, commandType,
                resultSets =>
                {
                    var first = resultSets.Read<T1>().AsQueryable();
                    var second = resultSets.Read<T2>().AsQueryable();
                    var third = resultSets.Read<T3>().AsQueryable();
                    var fourth = resultSets.Read<T4>().AsQueryable();
                    var fifth = resultSets.Read<T5>().AsQueryable();
                    var sixth = resultSets.Read<T6>().AsQueryable();
                    var seventh = resultSets.Read<T7>().AsQueryable();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>(first, second, third, fourth, fifth, sixth, seventh);
                }) as Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>;
        }

        public IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, TReturn>(
            string query,
            Func<T1, T2, TReturn> transformResultSelector,
            IDictionary<string, object> parameters = null,
            CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return SqlQueryMultiMapByDapper(parameters, (connection, dynamicParameters) => connection.Query(query, transformResultSelector, dynamicParameters, commandType: commandType, splitOn: splitOn));
        }

        public IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, TReturn>(string query,
            Func<T1, T2, T3, TReturn> transformResultSelector,
            IDictionary<string, object> parameters = null,
            CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return SqlQueryMultiMapByDapper(parameters, (connection, dynamicParameters) => connection.Query(query, transformResultSelector, dynamicParameters, commandType: commandType, splitOn: splitOn));
        }

        public IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, TReturn>(
            string query,
            Func<T1, T2, T3, T4, TReturn> transformResultSelector,
            IDictionary<string, object> parameters = null,
            CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return SqlQueryMultiMapByDapper(parameters, (connection, dynamicParameters) => connection.Query(query, transformResultSelector, dynamicParameters, commandType: commandType, splitOn: splitOn));
        }

        public IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, T5, TReturn>(
            string query,
            Func<T1, T2, T3, T4, T5, TReturn> transformResultSelector,
            IDictionary<string, object> parameters = null,
            CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return SqlQueryMultiMapByDapper(parameters, (connection, dynamicParameters) => connection.Query(query, transformResultSelector, dynamicParameters, commandType: commandType, splitOn: splitOn));
        }

        public IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, T5, T6, TReturn>(
            string query,
            Func<T1, T2, T3, T4, T5, T6, TReturn> transformResultSelector,
            IDictionary<string, object> parameters = null,
            CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return SqlQueryMultiMapByDapper(parameters, (connection, dynamicParameters) => connection.Query(query, transformResultSelector, dynamicParameters, commandType: commandType, splitOn: splitOn));
        }

        public IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, T5, T6, T7, TReturn>(
            string query,
            Func<T1, T2, T3, T4, T5, T6, T7, TReturn> transformResultSelector,
            IDictionary<string, object> parameters = null,
            CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return SqlQueryMultiMapByDapper(parameters, (connection, dynamicParameters) => connection.Query(query, transformResultSelector, dynamicParameters, commandType: commandType, splitOn: splitOn));
        }

       
        public void Execute(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            var sqlConnection = transaction?.Connection ?? Connection;
            var mustCloseConnection = false;
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    mustCloseConnection = true;
                    sqlConnection.Open();
                }

                DynamicParameters dynamicParameters = null;

                if (parameters != null && parameters.Count > 0)
                {
                    dynamicParameters = new DynamicParameters();
                    foreach (var parameter in parameters)
                    {
                        dynamicParameters.Add(parameter.Key, parameter.Value);
                    }
                }

                sqlConnection.Execute(query, dynamicParameters, commandType: commandType, transaction: transaction);
            }
            finally
            {
                if (mustCloseConnection)
                    sqlConnection.Close();
            }
        }

        private IEnumerable<T> SqlQueryByDapper<T>(string query, ICollection<KeyValuePair<string, object>> parameters, CommandType commandType, Func<dynamic, T> transformResultSelector)
        {
            var sqlConnection = Connection;
            try
            {
                sqlConnection.Open();

                DynamicParameters dynamicParameters = null;

                if (parameters != null && parameters.Count > 0)
                {
                    dynamicParameters = new DynamicParameters();
                    foreach (var parameter in parameters)
                    {
                        dynamicParameters.Add(parameter.Key, parameter.Value);
                    }
                }

                return transformResultSelector == null
                           ? sqlConnection.Query<T>(query, dynamicParameters, commandType: commandType)
                           : sqlConnection.Query(query, dynamicParameters, commandType: commandType).Select<dynamic, T>(x => transformResultSelector(x));
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private object SqlQueryMultipleByDapper(string query, ICollection<KeyValuePair<string, object>> parameters, CommandType commandType, Func<SqlMapper.GridReader, object> func)
        {
            var sqlConnection = Connection;
            try
            {
                sqlConnection.Open();

                DynamicParameters dynamicParameters = null;

                if (parameters != null && parameters.Count > 0)
                {
                    dynamicParameters = new DynamicParameters();
                    foreach (var parameter in parameters)
                    {
                        dynamicParameters.Add(parameter.Key, parameter.Value);
                    }
                }

                var resultSets = sqlConnection.QueryMultiple(query, dynamicParameters, commandType: commandType);
                return func(resultSets);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private IEnumerable<T> SqlQueryMultiMapByDapper<T>(ICollection<KeyValuePair<string, object>> parameters, Func<IDbConnection, DynamicParameters, IEnumerable<T>> multiMapFunc)
        {
            var sqlConnection = Connection;
            try
            {
                sqlConnection.Open();

                DynamicParameters dynamicParameters = null;

                if (parameters != null && parameters.Count > 0)
                {
                    dynamicParameters = new DynamicParameters();
                    foreach (var parameter in parameters)
                    {
                        dynamicParameters.Add(parameter.Key, parameter.Value);
                    }
                }

                return multiMapFunc(sqlConnection, dynamicParameters);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}