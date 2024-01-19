using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public static class ToObjectIdExtension
    {
        public static Guid ToObjectId(this string stringId)
        {
            return Guid.Parse(stringId);
        }
    }
}
