using Microsoft.EntityFrameworkCore;

namespace Share;

public class Admin : Itransferable, IinsertableData
{
    public Guid guid { get; set; }
    public DateTime dateTime { get; set; }
    public int GetId() => AdminId;


    public int AdminId { get; set; }
    public int PersonId { get; set; }

    public Person person { get; set; }
    public ICollection<User> users { get; set; }


    public void InsertToDataBase(DbContext dbContext)
    {
        this.AdminId = 0;
        PersonId = dbContext.Set<TransferrEdntities>().Single(L => L.LocalId == PersonId && L.Type == typeof(Person).ToString()).ServerId;
        dbContext.Add(this);
    }
}
