using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace ValorantReplayParser.Models;

[NetFieldExportGroup("/Game/GameModes/Bomb/TimedBomb.TimedBomb_C", minimalParseMode: ParseMode.Normal)]
public class TimedBomb : INetFieldExportGroup
{
    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)] // 3
    public object? RemoteRole { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)] // 12
    public object? Role { get; set; }

    [NetFieldExport("TimeRemainingToExplode", RepLayoutCmdType.PropertyFloat)] // 15
    public float? TimeRemainingToExplode { get; set; }
}
