namespace OSV.Models;

/// <summary>
/// Type of the severity.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SeverityType
{
    [EnumMember(Value = "UNSPECIFIED")]
    Unspecified,
    [EnumMember(Value = "CVSS_V3")]
    CvssV3,
}
