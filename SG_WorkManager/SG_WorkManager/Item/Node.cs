using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SG_WorkManager.Item
{
    public class Node
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public bool IsExpanded { get; set; }
        public List<Node> Children { get; set; } = new();

    }

}
