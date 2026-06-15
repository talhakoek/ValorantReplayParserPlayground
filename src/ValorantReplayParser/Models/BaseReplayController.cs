using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace ValorantReplayParser.Models;

[NetFieldExportGroup("/Game/Characters/_Core/BaseReplayController.BaseReplayController_C", minimalParseMode: ParseMode.Normal)]
[PlayerController("BaseReplayController_C")]
public class BaseReplayController : INetFieldExportGroup
{
    [NetFieldExportHandle(3, RepLayoutCmdType.Ignore)]
    public uint? RemoteRole { get; set; }

    [NetFieldExportHandle(12, RepLayoutCmdType.Ignore)]
    public uint? Role { get; set; }

    [NetFieldExportHandle(14, RepLayoutCmdType.PropertyObject)]
    public uint? PlayerState { get; set; }

    [NetFieldExportHandle(18, RepLayoutCmdType.PropertyVector)]
    public FVector? SpawnLocation { get; set; }
}
