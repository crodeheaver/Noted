using System;
using System.Collections.Generic;

namespace Noted.Shared
{
    public partial class User
    {
        public User()
        {
            UserNote = new HashSet<UserNote>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public string Password { get; set; }

        public ICollection<UserNote> UserNote { get; set; }
    }
}
