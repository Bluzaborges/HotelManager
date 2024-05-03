using Newtonsoft.Json;

namespace HotelManager.Abstraction.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException() { }

        public UserFriendlyException(string message) : base(message) { }

        public UserFriendlyException(string message,  Exception innerException) : base(message, innerException) { }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { message = Message });
        }
    }
}