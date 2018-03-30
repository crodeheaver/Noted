using System;
using System.Collections.Generic;

namespace Noted.Shared
{
    public partial class Note
    {
        public Note()
        {
            UserNote = new HashSet<UserNote>();
        }

        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public ICollection<UserNote> UserNote { get; set; }
    }
}
