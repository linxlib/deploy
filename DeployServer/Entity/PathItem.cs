using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entity
{
    public class PathItem
    {
        public string Text { get; set; }
        public string FullPath { get; set; }
        public List<PathItem> Children { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemType PathType { get; set; }
    }
    public enum ItemType
    {
        File,
        Directory
    }
}
