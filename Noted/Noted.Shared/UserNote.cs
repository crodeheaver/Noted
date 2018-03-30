using System;
using System.Collections.Generic;

namespace Noted.Shared
{
    public partial class UserNote
    {
        public Guid UserId { get; set; }
        public Guid NoteId { get; set; }
        public byte PermissionId { get; set; }

        public Note Note { get; set; }
        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
