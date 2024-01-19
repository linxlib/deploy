using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entity
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ActionType
    {
        ActionReboot,
        ActionStop,
        ActionStart,
    }
}
