using System.Text.Json;

namespace Share;

public class Transfer
{
    public IEnumerable<TransferableData> ConvertToTransableData(IEnumerable<Itransferable> transferableDataList)
    {


        IEnumerable<TransferableData> transferableList = transferableDataList.OrderBy(x => x.dateTime).Select(transferableData =>
        {
            Type type = transferableData.GetType();
            return new TransferableData()
            {
                guid = transferableData.guid,
                type = type,
                JsonData = JsonSerializer.Serialize(transferableData, type),
                dateTime = transferableData.dateTime,

            };
        });

        return transferableList;
    }


    public IEnumerable<Itransferable> ConvertFromTransferableData(IEnumerable<TransferableData> transferableDataList)
    {
        IEnumerable<Itransferable> transferableList = transferableDataList.OrderBy(x => x.dateTime)
            .Select(transferableData => JsonSerializer.Deserialize(transferableData.JsonData, transferableData.type) as Itransferable );
        return transferableList;
    }








}
