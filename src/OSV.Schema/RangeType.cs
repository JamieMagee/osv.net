namespace OSV.Schema;

/// <summary>
/// Type of the version information.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum RangeType
{
    [EnumMember(Value = "UNSPECIFIED")]
    Unspecified,
    [EnumMember(Value = "GIT")]
    Git,
    [EnumMember(Value = "SEMVER")]
    Semver,
    [EnumMember(Value = "ECOSYSTEM")]
    Ecosystem,
}
