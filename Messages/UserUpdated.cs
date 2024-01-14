﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPublisher.Messages
{
    public class UserUpdated
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
