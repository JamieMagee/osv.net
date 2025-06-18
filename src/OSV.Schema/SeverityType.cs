namespace OSV.Schema;

/// <summary>
/// Type of the severity.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SeverityType
{
    [EnumMember(Value = "UNSPECIFIED")]
    Unspecified,
    [EnumMember(Value = "CVSS_V2")]
    CvssV2,
    [EnumMember(Value = "CVSS_V3")]
    CvssV3,
    [EnumMember(Value = "CVSS_V4")]
    CvssV4,
    [EnumMember(Value = "Ubuntu")]
    Ubuntu,
}
