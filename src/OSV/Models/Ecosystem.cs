namespace OSV.Models;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Ecosystem
{
    /// <summary>
    /// The Go ecosystem.
    /// The name field is a Go module path.
    /// </summary>
    [EnumMember(Value = "Go")]
    Go,

    /// <summary>
    /// The NPM ecosystem.
    /// The name field is an NPM package name.
    /// </summary>
    [EnumMember(Value = "npm")]
    Npm,

    /// <summary>
    /// For reports from the OSS-Fuzz project that have no more appropriate ecosystem.
    /// The name field is the name assigned by the OSS-Fuzz project, as recorded in the submitted fuzzing configuration.
    /// </summary>
    [EnumMember(Value = "OSS-Fuzz")]
    OssFuzz,

    /// <summary>
    /// The Python PyPI ecosystem.
    /// The name field is a normalized PyPI package name.
    /// </summary>
    [EnumMember(Value = "PyPI")]
    PyPI,

    /// <summary>
    /// The RubyGems ecosystem.
    /// The name field is a gem name.
    /// </summary>
    [EnumMember(Value = "RubyGems")]
    RubyGems,

    /// <summary>
    /// The crates.io ecosystem for Rust.
    /// The name field is a crate name.
    /// </summary>
    [EnumMember(Value = "crates.io")]
    CratesIo,

    /// <summary>
    /// The PHP package manager ecosystem.
    /// The name is a package name.
    /// </summary>
    [EnumMember(Value = "Packagist")]
    Packagist,

    /// <summary>
    /// The Maven Java package ecosystem
    /// The name field is a Maven package name.
    /// </summary>
    [EnumMember(Value = "Maven")]
    Maven,

    /// <summary>
    /// The NuGet package ecosystem
    /// The name field is a NuGet package name.
    /// </summary>
    [EnumMember(Value = "NuGet")]
    NuGet,

    /// <summary>
    /// The Linux kernel.
    /// The only supported name is Kernel.
    /// </summary>
    [EnumMember(Value = "Linux")]
    Linux,

    /// <summary>
    /// The Debian package ecosystem.
    /// The name is the name of the source package.
    /// The ecosystem string might optionally have a :&lt;RELEASE&gt; suffix to scope the package to a particular Debian release.
    /// &lt;RELEASE&gt; is a numeric version specified in the Debian distro-info-data.
    /// For example, the ecosystem string “Debian:7” refers to the Debian 7 (wheezy) release.
    /// </summary>
    [EnumMember(Value = "Debian")]
    Debian,

    /// <summary>
    /// The package manager for the Erlang ecosystem.
    /// The name is a Hex package name.
    /// </summary>
    [EnumMember(Value = "Hex")]
    Hex,

    /// <summary>
    /// The Android ecosystem.
    /// The name field is the Android component name that the patch applies to, as shown in the Android Security Bulletins such as Framework, Media Framework and Kernel Component.
    /// The exhaustive list of components can be found at the Appendix.
    /// </summary>
    [EnumMember(Value = "Android")]
    Android,
}
