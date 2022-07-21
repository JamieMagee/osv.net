namespace OSV.Schema;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ReferenceType
{
    [EnumMember(Value = "NONE")]
    None,
    [EnumMember(Value = "WEB")]
    Web,
    [EnumMember(Value = "ADVISORY")]
    Advisory,
    [EnumMember(Value = "REPORT")]
    Report,
    [EnumMember(Value = "FIX")]
    Fix,
    [EnumMember(Value = "PACKAGE")]
    Package,
    [EnumMember(Value = "ARTICLE")]
    Article,
}
