namespace WardrivingMapper.Models;

public class InputDataModel
{
    public string MAC { get; set; } = string.Empty; 
    public string SSID { get; set; } = string.Empty; 
    public string[] AuthMode { get; set; } = [];
    public DateTime FirstSeen { get; set; }
    public int Channel { get; set; }
    public int Frequency { get; set; }
    public int RSSI { get; set; }
    public double CurrentLatitude { get; set; }
    public double CurrentLongitude { get; set; }
    public double AltitudeMeters { get; set; }
    public double AccuracyMeters { get; set; }
    public string? RCOIs { get; set; } = null;
    public int? MfgrId { get; set; }
    public string Type { get; set; } = "WIFI";

}
