using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace UriSerializationHelper;

[XmlRoot("uriAdresses")]
public class UriAddress
{
    [XmlIgnore]
    public string Scheme
    {
        get => this.AttrScheme.Name;
        set => this.AttrScheme.Name = value;
    }

    [XmlIgnore]
    public string Host
    {
        get => this.AttrHost.Name;
        set => this.AttrHost.Name = value;
    }

    [XmlElement("scheme")]
    public InnerNamed AttrScheme = new();

    [XmlElement("host")]
    public InnerNamed AttrHost = new();

    [XmlArrayItem("segment")]
    public List<string> Path { get; set; } = null!;

    [JsonIgnore]
    [XmlIgnore]
    public List<QueryElement> Query { get; set; } = null!;

    [JsonPropertyName("query")]
    [XmlArray("query")]
    [XmlArrayItem("parameter")]
    public List<QueryElement>? QuerySerializable
    {
        get => this.Query.Count > 0 ? this.Query : null;
    }

    public struct InnerNamed
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
