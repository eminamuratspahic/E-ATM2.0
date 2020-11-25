using System;
namespace DBClassLibrary
{
    public class LoginAttempts
    {
        public int UserId { get; set; }
        public int Attempts { get; set; }
        public DateTime Time { get; set; }

    }
}