﻿using System;
using System.Collections.Generic;

namespace TheAshenWolf.Lib.Editor
{
    [Serializable]
    public class DependencyJson
    {
        public Dictionary<string, string> dependencies;
        public Dictionary<string, LockedPackage> @lock;
    }
}