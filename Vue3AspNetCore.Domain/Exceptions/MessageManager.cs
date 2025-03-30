using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Vue3AspNetCore.Domain.Exceptions
{
    public class MessageManager
    {
        private static MessageManager? _instance;

        public static MessageManager? Instance => _instance;

        private readonly Dictionary<string, string> _messages = [];

        private MessageManager()
        {
            _messages = LoadMessages();
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                _instance = new MessageManager();
            }
        }

        private Dictionary<string, string> LoadMessages()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Messages.json");
            var json = File.ReadAllText(path);
            var messages = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            return messages;
        }

        public string GetMessage(string key)
        {
            if (_messages.ContainsKey(key))
            {
                return _messages[key];
            }

            return string.Empty;
        }
    }
}