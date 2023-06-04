using Dapper;
using Project.Domain.Entities.Users;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Data.SqlClient;

namespace Project.Infrastructure.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly QueryFactory queryFactory;

        public UserRepository(QueryFactory queryFactory)
        {
            this.queryFactory = queryFactory;
        }


        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ユーザー取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsersAsync(int id)
        {
            var query = queryFactory.Query("M_USER").OrderBy("USER_ID").Where("USER_ID",id);

            var result = new SqlServerCompiler().Compile(query);

            return await queryFactory.Connection.QueryAsync<User>(result.Sql, result.NamedBindings);
        }

        public Task InsertAsync(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> SearchAsync(SearchUser searchUser)
        {
            var query = queryFactory.Query("M_USER").Limit(searchUser.PageSize).Offset(searchUser.PageNumber);

            if (!string.IsNullOrEmpty(searchUser.UserId))
            {
                query = query.WhereLike("USER_ID", searchUser.UserId);
            }

            if (!string.IsNullOrEmpty(searchUser.UserName))
            {
                query = query.WhereLike("USER_NAME", searchUser.UserName);
            }
            if (!string.IsNullOrEmpty(searchUser.Authoty))
            {
                query = query.WhereLike("AUTHORITY", searchUser.Authoty);
            }

            var result = new SqlServerCompiler().Compile(query);

            return await queryFactory.Connection.QueryAsync<User>(result.Sql, result.NamedBindings);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
