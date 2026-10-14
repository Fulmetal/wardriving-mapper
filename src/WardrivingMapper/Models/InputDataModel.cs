using System;
using System.Linq;
using WardrivingMapper.Data.DataModels;
namespace WardrivingMapper.Models;

public class InputDataModel
{
    public string MAC { get; set; } = string.Empty; 
    public string SSID { get; set; } = string.Empty; 
    public string AuthMode { get; set; } = string.Empty;
    public DateTime FirstSeen { get; set; }
    public int? Channel { get; set; }
    public int? Frequency { get; set; }
    public int? RSSI { get; set; }
    public double CurrentLatitude { get; set; }
    public double CurrentLongitude { get; set; }
    public double AltitudeMeters { get; set; }
    public double AccuracyMeters { get; set; }
    public string? RCOIs { get; set; } = null;
    public int? MfgrId { get; set; }
    public string Type { get; set; } = "WIFI";

}

public static class InputDataModelMappingExtensions
{
    private static string Sanitize(string value) => 
        new(value.Where(c => !char.IsControl(c)).ToArray());

    public static RawData ToDataModel(this InputDataModel input)
    {
        return new RawData
        {
            MAC = input.MAC,
            SSID = Sanitize(input.SSID),
            AuthMode = Sanitize(input.AuthMode),
            FirstSeen = input.FirstSeen.ToUniversalTime(),
            Channel = input.Channel,
            Frequency = input.Frequency,
            RSSI = input.RSSI,
            CurrentLatitude = input.CurrentLatitude,
            CurrentLongitude = input.CurrentLongitude,
            AltitudeMeters = input.AltitudeMeters,
            AccuracyMeters = input.AccuracyMeters,
            RCOIs = input.RCOIs,
            MfgrId = input.MfgrId,
            Type = input.Type
        };
    }
}
