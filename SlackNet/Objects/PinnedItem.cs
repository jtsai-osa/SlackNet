﻿using System;

namespace SlackNet
{
    public class PinnedItem
    {
        public string Type { get; set; }
        public int Created { get; set; }
        public DateTime CreatedTimestamp => Created.ToDateTime().GetValueOrDefault();
        public string CreatedBy { get; set; }
    }
}