namespace Share;

public interface Itransferable
{
    public Guid guid { set; get; }
    public DateTime dateTime { set; get; }
    public int GetId();

}
