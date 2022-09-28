
using Microsoft.EntityFrameworkCore;

namespace Share;

public interface IinsertableData
{
    public void InsertToDataBase(DbContext dbContext);
}
