﻿using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using MySql.Data.MySqlClient;
using Pustalorc.MySqlDatabaseWrapper.Abstraction;
using Pustalorc.MySqlDatabaseWrapper.Configuration;

namespace Pustalorc.MySqlDatabaseWrapper.Implementations;

[UsedImplicitly]
public class MySqlDataWrapper<T1, T2> : MySqlDatabaseWrapper<T1, T2> where T1 : IConnectorConfiguration where T2 : class
{
    public MySqlDataWrapper(T1 configuration, IEqualityComparer<T2> comparer) : base(configuration, comparer,
        new MySqlConnectionStringBuilder(configuration.ConnectionString)
        {
            Server = configuration.MySqlServerAddress, Port = configuration.MySqlServerPort,
            Database = configuration.DatabaseName, UserID = configuration.DatabaseUsername,
            Password = configuration.DatabasePassword
        })
    {
    }

    protected override DbConnectionStringBuilder GetConnectionStringBuilder()
    {
        return new MySqlConnectionStringBuilder(Configuration.ConnectionString)
        {
            Server = Configuration.MySqlServerAddress,
            Port = Configuration.MySqlServerPort,
            Database = Configuration.DatabaseName,
            UserID = Configuration.DatabaseUsername,
            Password = Configuration.DatabasePassword
        };
    }

    protected override DbConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }
}