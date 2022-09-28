using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share;
using transfer;

namespace Receiver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetDatawithType(List<TransferableData> transferables)
        {
            Transfer transfer = new Transfer();
            var list = transfer.ConvertFromTransferableData(transferables);

            using (var context = new ServerDbContext())
            {
                context.Database.EnsureCreated();  
                using (var transact = await context.Database.BeginTransactionAsync())
                {
                    list.ToList().ForEach(transfer =>
                    {
                        TransferrEdntities entityLog  =new TransferrEdntities();

                        entityLog.LocalId = transfer.GetId();
                        entityLog.EntityGuid = transfer.guid;
                        entityLog.TransferrDate = DateTime.Now;
                        entityLog.Type = transfer.GetType().ToString();

                        (transfer as IinsertableData)?.InsertToDataBase(context);
                        context.SaveChanges();
                        entityLog.ServerId = transfer.GetId();

                        context.Add(entityLog);
                        context.SaveChanges();

                    });

                    transact.Commit();
                }
            }

            return Ok();
        }
    }
}

