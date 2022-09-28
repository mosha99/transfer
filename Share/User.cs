using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public class User : Itransferable, IinsertableData
    {
        public Guid guid { get; set; }
        public DateTime dateTime { get; set; }
        public int GetId() => UserId;


        public int UserId { get; set; }
        public int PersonId { get; set; }
        public int AdminId { get; set; }

        public Person person { get; set; }

        public string Role { get; set; }

        public void InsertToDataBase(DbContext dbContext)
        {
            this.UserId = 0;
            PersonId = dbContext.Set<TransferrEdntities>().Single(L => L.LocalId == PersonId && L.Type == typeof(Person).ToString()).ServerId;
            AdminId = dbContext.Set<TransferrEdntities>().Single(L => L.LocalId == AdminId && L.Type == typeof(Admin).ToString()).ServerId;
            dbContext.Add(this);
        }
    }
}
