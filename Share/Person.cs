using Microsoft.EntityFrameworkCore;

namespace Share;

public class Person : Itransferable, IinsertableData
{
    public Guid guid { get; set; }
    public DateTime dateTime { get; set; }
    public int GetId() => PersonId;


    public int PersonId { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string Mobile { get; set; }
    public string Mail { get; set; }

    public void InsertToDataBase(DbContext dbContext)
    {
        this.PersonId = 0;
        dbContext.Add(this);
    }
}
