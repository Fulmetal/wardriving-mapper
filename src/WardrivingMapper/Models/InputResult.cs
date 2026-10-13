namespace WardrivingMapper.Models;

public record ImportResult(int TotalRecords, int WifiCount, int BleCount, int BtCount, int LteCount)
{
    public bool HasData => TotalRecords > 0;
}
