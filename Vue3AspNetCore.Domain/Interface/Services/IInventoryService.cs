using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue3AspNetCore.Domain.Entities.Products;

namespace Vue3AspNetCore.Domain.Interface.Services
{
    public interface IInventoryService
    {
        /// <summary>
        /// すべての製品を取得します
        /// </summary>
        /// <returns>製品のコレクション</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync();

        /// <summary>
        /// 指定されたIDの製品を取得します
        /// </summary>
        /// <param name="id">製品ID</param>
        /// <returns>製品オブジェクト</returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// 指定された検索語句に一致する製品を検索します
        /// </summary>
        /// <param name="term">検索語句</param>
        /// <returns>一致する製品のコレクション</returns>
        Task<IEnumerable<Product>> SearchProductsAsync(string term);

        /// <summary>
        /// 新しい製品を追加します
        /// </summary>
        /// <param name="product">追加する製品</param>
        /// <returns>追加された製品</returns>
        Task<Product> AddProductAsync(Product product);

        /// <summary>
        /// 製品情報を更新します
        /// </summary>
        /// <param name="product">更新する製品</param>
        /// <returns>更新された製品</returns>
        Task<Product> UpdateProductAsync(Product product);

        /// <summary>
        /// 指定されたIDの製品を削除します
        /// </summary>
        /// <param name="id">削除する製品のID</param>
        /// <returns>削除が成功したかどうか</returns>
        Task<bool> DeleteProductAsync(int id);

        /// <summary>
        /// すべての製品カテゴリを取得します
        /// </summary>
        /// <returns>製品カテゴリのコレクション</returns>
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        /// <summary>
        /// 製品の在庫数を更新します
        /// </summary>
        /// <param name="productId">製品ID</param>
        /// <param name="quantity">更新する数量</param>
        /// <returns>更新後の在庫数</returns>
        Task<int> UpdateStockQuantityAsync(int productId, int quantity);

        /// <summary>
        /// 在庫が少ない製品を取得します
        /// </summary>
        /// <param name="threshold">閾値</param>
        /// <returns>在庫が閾値以下の製品のコレクション</returns>
        Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold);
    }
}