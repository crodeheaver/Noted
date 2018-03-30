using System;
using System.Collections.Generic;

namespace Noted.Domain
{
    public partial class Permission
    {
        public Permission()
        {
            UserNote = new HashSet<UserNote>();
        }

        public byte Id { get; set; }
        public string Value { get; set; }

        public ICollection<UserNote> UserNote { get; set; }
    }
}
