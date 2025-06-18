namespace OSV.Schema;

/// <summary>
/// The type or role of the individual or entity being credited.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum CreditType
{
    [EnumMember(Value = "FINDER")]
    Finder,
    [EnumMember(Value = "REPORTER")]
    Reporter,
    [EnumMember(Value = "ANALYST")]
    Analyst,
    [EnumMember(Value = "COORDINATOR")]
    Coordinator,
    [EnumMember(Value = "REMEDIATION_DEVELOPER")]
    RemediationDeveloper,
    [EnumMember(Value = "REMEDIATION_REVIEWER")]
    RemediationReviewer,
    [EnumMember(Value = "REMEDIATION_VERIFIER")]
    RemediationVerifier,
    [EnumMember(Value = "TOOL")]
    Tool,
    [EnumMember(Value = "SPONSOR")]
    Sponsor,
    [EnumMember(Value = "OTHER")]
    Other,
}
