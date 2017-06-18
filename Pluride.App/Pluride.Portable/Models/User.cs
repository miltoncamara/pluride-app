using Pluride.App.Models;

namespace Pluride.App.Portable.Models
{
    public class User : TableData
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Phone { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string PushNotificationCode { get; set; }
    }
}
