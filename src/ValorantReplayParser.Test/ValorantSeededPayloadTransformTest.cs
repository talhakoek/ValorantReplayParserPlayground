using Unreal.Core;
using Xunit;

namespace ValorantReplayParser.Test;

public class ValorantSeededPayloadTransformTest
{
    private const string PayloadHex = "BFDF6F9EA1F27BA00000C66EAFAF2E0000339C0DD34B0C45C48063038003562A43C0C949";
    private const string TransformedHex = "100CA461300F080493400100000040394E5120000000B0792C626000000080FE7F3C2000";
    private const int PayloadBits = 287;
    private const uint ActorNetGuid = 2;

    [Fact]
    public void ActorSeedTransform_ProducesKnownBackcompatFieldChain()
    {
        var payload = Convert.FromHexString(PayloadHex);
        var transformed = ValorantSeededPayloadTransform.Apply(payload, PayloadBits, PayloadBits ^ ActorNetGuid);

        Assert.Equal(TransformedHex, Convert.ToHexString(transformed));

        var reader = new NetBitReader(transformed, PayloadBits);
        reader.ReadBit();

        Assert.Equal(4u, reader.ReadIntPacked());
        Assert.Equal(3u, reader.ReadIntPacked());
        reader.SkipBits(3);

        Assert.Equal(13u, reader.ReadIntPacked());
        Assert.Equal(3u, reader.ReadIntPacked());
        reader.SkipBits(3);

        Assert.Equal(15u, reader.ReadIntPacked());
        Assert.Equal(8u, reader.ReadIntPacked());
        reader.SkipBits(8);

        Assert.Equal(19u, reader.ReadIntPacked());
        Assert.Equal(192u, reader.ReadIntPacked());
        reader.SkipBits(192);

        Assert.Equal(0u, reader.ReadIntPacked());
        Assert.Equal(0, reader.GetBitsLeft());
    }
}
