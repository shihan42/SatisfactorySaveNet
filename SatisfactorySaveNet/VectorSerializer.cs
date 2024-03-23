using SatisfactorySaveNet.Abstracts;
using SatisfactorySaveNet.Abstracts.Maths.Data;
using SatisfactorySaveNet.Abstracts.Maths.Vector;
using System.IO;

namespace SatisfactorySaveNet;

public class VectorSerializer : IVectorSerializer
{
    public static readonly IVectorSerializer Instance = new VectorSerializer();

    public Vector4 DeserializeVec4(BinaryReader reader)
    {
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        var w = reader.ReadSingle();

        return new Vector4(x, y, z, w);
    }

    public Vector3 DeserializeVec3(BinaryReader reader)
    {
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();

        return new Vector3(x, y, z);
    }

    public Vector3D DeserializeVec3D(BinaryReader reader)
    {
        var x = reader.ReadDouble();
        var y = reader.ReadDouble();
        var z = reader.ReadDouble();

        return new Vector3D(x, y, z);
    }

    public Vector2 DeserializeVec2(BinaryReader reader)
    {
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();

        return new Vector2(x, y);
    }

    public Quaternion DeserializeQuaternion(BinaryReader reader)
    {
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        var w = reader.ReadSingle();

        return new Quaternion(x, y, z, w);
    }
}