using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Products;

namespace Vue3AspNetCore.Domain.Interface.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// すべての製品を取得します
        /// </summary>
        /// <returns>製品のコレクション</returns>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// 指定されたIDの製品を取得します
        /// </summary>
        /// <param name="id">製品ID</param>
        /// <returns>製品オブジェクト、存在しない場合はnull</returns>
        Task<Product> GetByIdAsync(int id);

        /// <summary>
        /// 指定された製品コードの製品を取得します
        /// </summary>
        /// <param name="code">製品コード</param>
        /// <returns>製品オブジェクト、存在しない場合はnull</returns>
        Task<Product> GetByCodeAsync(string code);

        /// <summary>
        /// 指定された検索語句に一致する製品を検索します
        /// </summary>
        /// <param name="searchTerm">検索語句</param>
        /// <returns>一致する製品のコレクション</returns>
        Task<IEnumerable<Product>> SearchAsync(string searchTerm);

        /// <summary>
        /// 製品を追加します
        /// </summary>
        /// <param name="product">追加する製品</param>
        void Add(Product product);

        /// <summary>
        /// 製品を更新します
        /// </summary>
        /// <param name="product">更新する製品</param>
        void Update(Product product);

        /// <summary>
        /// 製品を削除します
        /// </summary>
        /// <param name="product">削除する製品</param>
        void Remove(Product product);
    }
}