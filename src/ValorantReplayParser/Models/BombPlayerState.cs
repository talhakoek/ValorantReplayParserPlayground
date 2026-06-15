using Unreal.Core;
using Unreal.Core.Attributes;
using Unreal.Core.Contracts;
using Unreal.Core.Models.Enums;

namespace ValorantReplayParser.Models;

[NetFieldExportGroup("/Game/GameModes/Bomb/BombPlayerState.BombPlayerState_C", minimalParseMode: ParseMode.Normal)]
public class BombPlayerState : INetFieldExportGroup
{
    private const uint CrosshairSettingsStartHandle = 48;

    [NetFieldExport("RemoteRole", RepLayoutCmdType.Ignore)]
    public uint? RemoteRole { get; set; }

    [NetFieldExport("Owner", RepLayoutCmdType.Ignore)]
    public uint? Owner { get; set; }

    [NetFieldExport("Role", RepLayoutCmdType.Ignore)]
    public uint? Role { get; set; }

    [NetFieldExportHandle(14, RepLayoutCmdType.PropertyInt)]
    public int? PlayerId { get; set; }

    [NetFieldExportHandle(15, RepLayoutCmdType.PropertyUInt16)]
    public ushort Ping { get; set; }

    [NetFieldExportHandle(20, RepLayoutCmdType.Ignore)]
    public uint? UniqueId { get; set; }

    [NetFieldExportHandle(22, RepLayoutCmdType.PropertyInt)]
    public int? CompetitiveTier { get; set; }

    [NetFieldExport("Subject", RepLayoutCmdType.Ignore)]
    public uint? Subject { get; set; }

    [NetFieldExport("PlayerInfo", RepLayoutCmdType.Ignore)]
    public uint? PlayerInfo { get; set; }

    [NetFieldExport("PlayerMatchStatsComponent", RepLayoutCmdType.Ignore)]
    public uint? PlayerMatchStatsComponent { get; set; }

    [NetFieldExport("PlayerScoreComponent", RepLayoutCmdType.Ignore)]
    public uint? PlayerScoreComponent { get; set; }

    [NetFieldExport("AFKDetectionComponent", RepLayoutCmdType.Ignore)]
    public uint? AFKDetectionComponent { get; set; }


    [NetFieldExportHandle(197, RepLayoutCmdType.PropertyString)]
    public string? ProfileName { get; set; }
    // public CrosshairSettings CrosshairSettings { get; } = new();

    /*public bool ReadFieldHandle(uint handle, NetBitReader reader)
    {
        if (handle < CrosshairSettingsStartHandle)
        {
            return false;
        }

        return CrosshairSettings.ReadHandle((int)(handle - CrosshairSettingsStartHandle), reader);
    } */
}

public class CrosshairSettings
{
    public LineCrosshairSettings Primary { get; } = new();
    public LineCrosshairSettings ADS { get; } = new();
    public LineCrosshairSettings FocusMode { get; } = new();
    public SniperCrosshairSettings Sniper { get; } = new();
    public bool? bUsePrimaryCrosshairForADS { get; set; }
    public bool? bUsePrimaryCrosshairForFocusMode { get; set; }
    public bool? bUseCustomCrosshairOnAllPrimary { get; set; }
    public bool? bUseAdvancedOptions { get; set; }
    public bool? bScaleToResolution { get; set; }
    public string? ProfileName { get; set; }

    public bool ReadHandle(int handle, NetBitReader reader)
    {
        if (handle < LineCrosshairSettings.HandleCount)
        {
            return Primary.ReadHandle(handle, reader);
        }

        handle -= LineCrosshairSettings.HandleCount;
        if (handle < LineCrosshairSettings.HandleCount)
        {
            return ADS.ReadHandle(handle, reader);
        }

        handle -= LineCrosshairSettings.HandleCount;
        if (handle < LineCrosshairSettings.HandleCount)
        {
            return FocusMode.ReadHandle(handle, reader);
        }

        handle -= LineCrosshairSettings.HandleCount;
        if (handle < SniperCrosshairSettings.HandleCount)
        {
            return Sniper.ReadHandle(handle, reader);
        }

        handle -= SniperCrosshairSettings.HandleCount;
        switch (handle)
        {
            case 0: bUsePrimaryCrosshairForADS = reader.SerializePropertyBool(); return true;
            case 1: bUsePrimaryCrosshairForFocusMode = reader.SerializePropertyBool(); return true;
            case 2: bUseCustomCrosshairOnAllPrimary = reader.SerializePropertyBool(); return true;
            case 3: bUseAdvancedOptions = reader.SerializePropertyBool(); return true;
            case 4: bScaleToResolution = reader.SerializePropertyBool(); return true;
            case 5: ProfileName = reader.SerializePropertyString(); return true;
            default: return false;
        }
    }
}

public class SniperCrosshairSettings
{
    public const int HandleCount = 12;

    public Color CenterDotColor { get; } = new();
    public Color CenterDotColorCustom { get; } = new();
    public bool? bUseCustomCenterDotColor { get; set; }
    public float? CenterDotSize { get; set; }
    public float? CenterDotOpacity { get; set; }
    public bool? bDisplayCenterDot { get; set; }

    public bool ReadHandle(int handle, NetBitReader reader)
    {
        if (handle < Color.HandleCount)
        {
            return CenterDotColor.ReadHandle(handle, reader);
        }

        handle -= Color.HandleCount;
        if (handle < Color.HandleCount)
        {
            return CenterDotColorCustom.ReadHandle(handle, reader);
        }

        handle -= Color.HandleCount;
        switch (handle)
        {
            case 0: bUseCustomCenterDotColor = reader.SerializePropertyBool(); return true;
            case 1: CenterDotSize = reader.SerializePropertyFloat(); return true;
            case 2: CenterDotOpacity = reader.SerializePropertyFloat(); return true;
            case 3: bDisplayCenterDot = reader.SerializePropertyBool(); return true;
            default: return false;
        }
    }
}

public class LineCrosshairSettings
{
    public const int HandleCount = 47;

    public Color Color { get; } = new();
    public Color ColorCustom { get; } = new();
    public bool? bUseCustomColor { get; set; }
    public bool? bHasOutline { get; set; }
    public float? OutlineThickness { get; set; }
    public Color OutlineColor { get; } = new();
    public float? OutlineOpacity { get; set; }
    public float? CenterDotSize { get; set; }
    public float? CenterDotOpacity { get; set; }
    public bool? bDisplayCenterDot { get; set; }
    public bool? bFadeCrosshairWithFiringError { get; set; }
    public bool? bShowSpectatedPlayerCrosshair { get; set; }
    public bool? bHideCrosshair { get; set; }
    public bool? bFixMinErrorAcrossWeapons { get; set; }
    public LineCrosshairSectionSettings InnerLines { get; } = new();
    public LineCrosshairSectionSettings OuterLines { get; } = new();

    public bool ReadHandle(int handle, NetBitReader reader)
    {
        if (handle < Color.HandleCount)
        {
            return Color.ReadHandle(handle, reader);
        }

        handle -= Color.HandleCount;
        if (handle < Color.HandleCount)
        {
            return ColorCustom.ReadHandle(handle, reader);
        }

        handle -= Color.HandleCount;
        switch (handle)
        {
            case 0: bUseCustomColor = reader.SerializePropertyBool(); return true;
            case 1: bHasOutline = reader.SerializePropertyBool(); return true;
            case 2: OutlineThickness = reader.SerializePropertyFloat(); return true;
        }

        handle -= 3;
        if (handle < Color.HandleCount)
        {
            return OutlineColor.ReadHandle(handle, reader);
        }

        handle -= Color.HandleCount;
        switch (handle)
        {
            case 0: OutlineOpacity = reader.SerializePropertyFloat(); return true;
            case 1: CenterDotSize = reader.SerializePropertyFloat(); return true;
            case 2: CenterDotOpacity = reader.SerializePropertyFloat(); return true;
            case 3: bDisplayCenterDot = reader.SerializePropertyBool(); return true;
            case 4: bFadeCrosshairWithFiringError = reader.SerializePropertyBool(); return true;
            case 5: bShowSpectatedPlayerCrosshair = reader.SerializePropertyBool(); return true;
            case 6: bHideCrosshair = reader.SerializePropertyBool(); return true;
            case 7: bFixMinErrorAcrossWeapons = reader.SerializePropertyBool(); return true;
        }

        handle -= 8;
        if (handle < LineCrosshairSectionSettings.HandleCount)
        {
            return InnerLines.ReadHandle(handle, reader);
        }

        handle -= LineCrosshairSectionSettings.HandleCount;
        return handle < LineCrosshairSectionSettings.HandleCount && OuterLines.ReadHandle(handle, reader);
    }
}

public class LineCrosshairSectionSettings
{
    public const int HandleCount = 12;

    public float? LineThickness { get; set; }
    public float? LineLength { get; set; }
    public float? LineLengthVertical { get; set; }
    public bool? bAllowVertScaling { get; set; }
    public float? LineOffset { get; set; }
    public bool? bShowMovementError { get; set; }
    public bool? bShowShootingError { get; set; }
    public bool? bShowMinError { get; set; }
    public float? Opacity { get; set; }
    public bool? bShowLines { get; set; }
    public float? FiringErrorScale { get; set; }
    public float? MovementErrorScale { get; set; }

    public bool ReadHandle(int handle, NetBitReader reader)
    {
        switch (handle)
        {
            case 0: LineThickness = reader.SerializePropertyFloat(); return true;
            case 1: LineLength = reader.SerializePropertyFloat(); return true;
            case 2: LineLengthVertical = reader.SerializePropertyFloat(); return true;
            case 3: bAllowVertScaling = reader.SerializePropertyBool(); return true;
            case 4: LineOffset = reader.SerializePropertyFloat(); return true;
            case 5: bShowMovementError = reader.SerializePropertyBool(); return true;
            case 6: bShowShootingError = reader.SerializePropertyBool(); return true;
            case 7: bShowMinError = reader.SerializePropertyBool(); return true;
            case 8: Opacity = reader.SerializePropertyFloat(); return true;
            case 9: bShowLines = reader.SerializePropertyBool(); return true;
            case 10: FiringErrorScale = reader.SerializePropertyFloat(); return true;
            case 11: MovementErrorScale = reader.SerializePropertyFloat(); return true;
            default: return false;
        }
    }
}

public class Color
{
    public const int HandleCount = 4;

    public int? B { get; set; }
    public int? G { get; set; }
    public int? R { get; set; }
    public int? A { get; set; }

    public bool ReadHandle(int handle, NetBitReader reader)
    {
        switch (handle)
        {
            case 0: B = reader.SerializePropertyByte(); return true;
            case 1: G = reader.SerializePropertyByte(); return true;
            case 2: R = reader.SerializePropertyByte(); return true;
            case 3: A = reader.SerializePropertyByte(); return true;
            default: return false;
        }
    }
}
