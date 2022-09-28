namespace Share;

public class TransferrEdntities
{
    public int TransferrEdntitiesId { get; set; }
    public Guid EntityGuid { get; set; }
    public int LocalId { get; set; }
    public int ServerId { get; set; }
    public string Type { get; set; }
    public DateTime TransferrDate { get; set; }
}
