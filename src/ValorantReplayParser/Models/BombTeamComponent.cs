using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace ValorantReplayParser.Models;

[NetFieldExportGroup("/Script/ShooterGame.BombTeamComponent", ParseMode.Full)]
public class BombTeamComponent : INetFieldExportGroup
{
    [NetFieldExport("Team", RepLayoutCmdType.Enum)] // 2
    public EAresTeam Team { get; set; }
}
