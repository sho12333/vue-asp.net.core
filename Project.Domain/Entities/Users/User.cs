namespace Project.Domain.Entities.Users
{
    /// <summary>
    /// ユーザー情報を提供する
    /// </summary>
    public class User
    {
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? UserShortName { get; set; }

        public string? Authority { get; set; }

        public string? MailAddress { get; set; }

        public string? Password { get; set; }

        public string? DeleteFlag { get; set; }
    }
}
