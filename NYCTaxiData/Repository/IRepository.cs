using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NYCTaxiFHVData.Models;

namespace NYCTaxiFHVData.Repository
{
    public interface IRepository
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
        IQueryable<T> SqlQuery<T>(string query, IDictionary<string, object> parameters = null, bool lazyLoad = true, CommandType commandType = CommandType.Text, Func<dynamic, T> transformResultSelector = null) where T : class;

        IEnumerable<T> SqlQueryValueType<T>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, Func<dynamic, T> transformResultSelector = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>> SqlQueryMultiple<T1, T2>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> SqlQueryMultiple<T1, T2, T3>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> SqlQueryMultiple<T1, T2, T3, T4>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> SqlQueryMultiple<T1, T2, T3, T4, T5>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> SqlQueryMultiple<T1, T2, T3, T4, T5, T6>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> SqlQueryMultiple<T1, T2, T3, T4, T5, T6, T7>(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);

        IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, TReturn>(string query, Func<T1, T2, TReturn> transformResultSelector, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, TReturn>(string query, Func<T1, T2, T3, TReturn> transformResultSelector, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, TReturn>(string query, Func<T1, T2, T3, T4, TReturn> transformResultSelector, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, T5, TReturn>(string query, Func<T1, T2, T3, T4, T5, TReturn> transformResultSelector, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, T5, T6, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, TReturn> transformResultSelector, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        IEnumerable<TReturn> SqlQueryMultiMap<T1, T2, T3, T4, T5, T6, T7, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> transformResultSelector, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, string splitOn = "Id");

        void Execute(string query, IDictionary<string, object> parameters = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null);
    }
}
