using Pustalorc.Libraries.MySqlConnectorWrapper.Queries;

namespace Pustalorc.Libraries.MySqlConnectorWrapper.Delegates
{
    /// <summary>
    ///     Callback for any queries that finished execution and required a return value.
    /// </summary>
    /// <param name="query">The query object that finished execution.</param>
    /// <param name="result">The result of the query.</param>
    public delegate void QueryCallback(Query query, object result);
}