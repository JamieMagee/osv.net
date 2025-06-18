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
    [EnumMember(Value = "ARTICLE")]
    Article,
    [EnumMember(Value = "DETECTION")]
    Detection,
    [EnumMember(Value = "DISCUSSION")]
    Discussion,
    [EnumMember(Value = "REPORT")]
    Report,
    [EnumMember(Value = "FIX")]
    Fix,
    [EnumMember(Value = "INTRODUCED")]
    Introduced,
    [EnumMember(Value = "PACKAGE")]
    Package,
    [EnumMember(Value = "EVIDENCE")]
    Evidence,
}
