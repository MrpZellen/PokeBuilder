﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.Models
{
    public class MongoDBSettings
    {
        public string AtlasURI { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; internal set; }
    }
}
