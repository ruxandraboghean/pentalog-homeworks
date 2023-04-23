using Dapper;
using MonkeyFinder.Core.Entities;
using MonkeyFinder.Core.Interfaces;
using MonkeyFinder.DataAccess;
using MonkeyFinder.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyFinder.Repository
{
    public class MonkeyRepository : IMonkeyRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MonkeyRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            const string query = "SELECT * FROM Monkey";

            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);

            return result;
        }

        public async Task<IEnumerable<Monkey>> SearchMonkeyByIdAsync(int id)
        {
            string query = $"SELECT * FROM Monkey WHERE id ={1} ";

            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);

            return result;
        }

        public async Task<IEnumerable<Monkey>> AddMonkeysAsync(Monkey monkey)
        {
            string query = "INSERT INTO Monkey(Name, Location, Details, Population, Latitude, Longitude) " +
                "VALUES('MonkeyIasi', 'Iasi', 'Lives in Europe', 200, -18.9, 20.8)";

            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);

            return result;
        }

     

        public async Task<IEnumerable<Monkey>> UpdateMonkeysAsync(Monkey monkey)
        {
            string updateQuery = @"UPDATE [dbo].[Monkey] SET Name = 'MonkeyIasiUpdate' WHERE Name = 'MonkeyIasi'";
            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(updateQuery);

            return result;
        }


        public async Task<IEnumerable<Monkey>> DeleteMonkeysAsync(Monkey monkey)
        {
            string deleteQuery = @"DELETE FROM [dbo].[Monkey] WHERE Name = 'MonkeyIasiUpdate'";

            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(deleteQuery);

            return result;
        }

    }
}
