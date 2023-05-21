namespace Project.Server.Models.Users
{
    /// <summary>
    /// 検索用ユーザー
    /// </summary>
    public class SearchUser
    {
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? Authoty { get; set; }
    }
}
