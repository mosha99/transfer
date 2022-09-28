global using System.Text.Json.Serialization;

namespace Share;
public class TransferableData : Itransferable
{
    public Guid guid { set; get; }
    public DateTime dateTime { set; get; }
    public string JsonData { set; get; }

    [JsonIgnore]
    public Type type { set { if(value != null ) StringType = value.ToString(); } get { return Type.GetType(StringType); } }
    public string StringType { set; get; }

    public int GetId()
    {
        throw new NotImplementedException();
    }
}
