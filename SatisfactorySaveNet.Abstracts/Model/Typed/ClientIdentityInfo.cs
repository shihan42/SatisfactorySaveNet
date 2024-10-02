using System.Collections.Generic;

namespace SatisfactorySaveNet.Abstracts.Model.Typed;

public enum AccountType
{
    // See https://github.com/EpicGames/UnrealEngine/blob/5.3.2-release/Engine/Source/Runtime/CoreOnline/Public/Online/CoreOnline.h#L226
    Null,
    // Epic Online Services
    Epic,
    // Xbox services
    Xbox,
    // PlayStation Network
    PSN,
    // Nintendo
    Nintendo,
    // Unused,
    Reserved_5,
    // Steam
    Steam,
    // Google
    Google,
    // GooglePlay
    GooglePlay,
    // Apple
    Apple,
    // GameKit
    AppleGameKit,
    // Samsung
    Samsung,
    // Oculus
    Oculus,
    // Tencent
    Tencent,
    // Reserved for future use/platform extensions
    Reserved_14,
    Reserved_15,
    Reserved_16,
    Reserved_17,
    Reserved_18,
    Reserved_19,
    Reserved_20,
    Reserved_21,
    Reserved_22,
    Reserved_23,
    Reserved_24,
    Reserved_25,
    Reserved_26,
    Reserved_27,
    // For game specific Online Services
    GameDefined_0 = 28,
    GameDefined_1,
    GameDefined_2,
    GameDefined_3,
    // None, used internally to resolve Platform or Default if they are not configured
    None = 253,
    // Platform native, may not exist for all platforms
    Platform = 254,
    // Default, configured via ini,
    Default = 255
}

public class ClientIdentityInfo : TypedData
{
    public override TypedDataConstraint Type => TypedDataConstraint.ClientIdentityInfo;

    public string OfflineId { get; set; } = string.Empty;

    public Dictionary<AccountType, byte[]> Accounts { get; set; } = [];
}
