using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Core.Caching.Redis
{
    public class RedisServer
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _database;
        private IServer _server;
        private readonly string _configurationString;
        private int _currentDatabaseId = 0;

        public RedisServer(IConfiguration configuration)
        {
            string host = configuration.GetSection("RedisConfiguration:Host").Value;
            string port = configuration.GetSection("RedisConfiguration:Port").Value;

            _configurationString = $"{host}:{port}";

            _connectionMultiplexer = ConnectionMultiplexer.Connect(_configurationString);
            _database = _connectionMultiplexer.GetDatabase();
            _server = _connectionMultiplexer.GetServer(_configurationString);
        }

        public IDatabase Database => _database;
        public IServer Server => _server;

        public void FlushDatabase()
        {
            _connectionMultiplexer.GetServer(_configurationString).FlushDatabase(_currentDatabaseId);
        }
    }
}
