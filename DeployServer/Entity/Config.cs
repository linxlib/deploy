using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Config: BaseEntity
    {

        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
