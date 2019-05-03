using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicAroundWebAPI.Models
{
    public class ChatModel
    {
        public string CustomerId { get; set; }
        public string Id { get; set; }
        public string message { get; set; }
        public string platformId { get; set; }
        public DateTime timestamp { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
    }
}