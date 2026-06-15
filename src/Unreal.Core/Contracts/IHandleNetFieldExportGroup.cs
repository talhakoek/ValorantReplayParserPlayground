namespace Unreal.Core.Contracts;

public interface IHandleNetFieldExportGroup
{
    bool ReadFieldHandle(uint handle, NetBitReader reader);
}
