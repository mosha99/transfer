global using Share;
global using System.Collections;
global using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Sender;

List<Itransferable> pepole = new List<Itransferable>();

//pepole.Add(new English() { Name = "moein", dateTime = DateTime.Now.AddDays(-4), guid = Guid.NewGuid() });
//pepole.Add(new Persian() { Esm = "ali", dateTime = DateTime.Now.AddDays(-4), guid = Guid.NewGuid() });
//pepole.Add(new English() { Name = "hosein", dateTime = DateTime.Now.AddDays(-4), guid = Guid.NewGuid() });
//pepole.Add(new Persian() { Esm = "mahdi", dateTime = DateTime.Now.AddDays(-4), guid = Guid.NewGuid() });
//pepole.Add(new English() { Name = "mohammad", dateTime = DateTime.Now.AddDays(-4), guid = Guid.NewGuid() });








using (var context = new MyDbContex())
{
    try
    {
        #region seed
        context.Database.EnsureCreated();
        if (context.people.Count() == 0)
            using (var transact = await context.Database.BeginTransactionAsync())
            {
                var personAdmin = new Person()
                {
                    dateTime = DateTime.Now,
                    Family = "sha",
                    guid = Guid.NewGuid(),
                    Mail = "mosha.dnd@gmail.com",
                    Mobile = "09013231042",
                    Name = "moein"
                };
                context.Add(personAdmin);
                context.SaveChanges();
                var Admin = new Admin()
                {
                    dateTime = DateTime.Now,
                    guid = Guid.NewGuid(),
                    PersonId = personAdmin.PersonId,
                };
                context.Add(Admin);
                context.SaveChanges();
                var personAdmin2 = new Person()
                {
                    dateTime = DateTime.Now,
                    Family = "sha2",
                    guid = Guid.NewGuid(),
                    Mail = "mosha.dnd@gmail.com",
                    Mobile = "09013231042",
                    Name = "moein2"
                };
                context.Add(personAdmin2);
                context.SaveChanges();
                var Admin2 = new Admin()
                {
                    dateTime = DateTime.Now,
                    guid = Guid.NewGuid(),
                    PersonId = personAdmin2.PersonId,
                };
                context.Add(Admin2);
                context.SaveChanges();
                var up1 = new Person()
                {
                    dateTime = DateTime.Now,
                    Family = "sha3",
                    guid = Guid.NewGuid(),
                    Mail = "mosha.dnd@gmail.com",
                    Mobile = "09013231042",
                    Name = "moein3"
                };
                context.Add(up1);
                context.SaveChanges();
                var U1 = new User()
                {
                    PersonId = up1.PersonId,
                    guid = Guid.NewGuid(),
                    AdminId = Admin.AdminId,
                    dateTime = DateTime.Now,
                    Role = "user"
                };
                context.Add(U1);
                context.SaveChanges();
                var up2 = new Person()
                {
                    dateTime = DateTime.Now,
                    Family = "sha4",
                    guid = Guid.NewGuid(),
                    Mail = "mosha.dnd@gmail.com",
                    Mobile = "09013231042",
                    Name = "moein4"
                };
                context.Add(up2);
                context.SaveChanges();
                var U2 = new User()
                {
                    PersonId = up2.PersonId,
                    guid = Guid.NewGuid(),
                    AdminId = Admin.AdminId,
                    dateTime = DateTime.Now,
                    Role = "user"
                };
                context.Add(U2);
                context.SaveChanges();
                transact.Commit();
            }

        #endregion

        var Users = context.Set<User>().AsNoTracking();
        var Admins = context.Set<Admin>().AsNoTracking();
        var persons = context.Set<Person>().AsNoTracking();

        pepole.AddRange(Users);
        pepole.AddRange(Admins);
        pepole.AddRange(persons);

    }
    catch (Exception ex)
    {
        throw;
    }
}




Transfer transfer = new Transfer();
var list = transfer.ConvertToTransableData(pepole);

sendPostREquest("https://localhost:7165/api/Values", JsonSerializer.Serialize(list));




void sendPostREquest(string url, string Data)
{
    var transferList = transfer.ConvertToTransableData(pepole);
    var client = new RestClient(url);
    var request = new RestRequest(string.Empty, method: Method.Post);
    request.AddHeader("Content-Type", "application/json");
    var body = Data;
    request.AddParameter("application/json", body, ParameterType.RequestBody);
    var response = client.Execute(request);
    Console.WriteLine(response.Content);
}