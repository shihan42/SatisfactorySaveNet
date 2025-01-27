using SatisfactorySaveNet.Abstracts.Maths.Data;
using SatisfactorySaveNet.Abstracts.Maths.Vector;
using System.IO;

namespace SatisfactorySaveNet.Abstracts;

public interface IVectorSerializer
{
    public Vector2 DeserializeVec2(BinaryReader reader);
    public Vector2I DeserializeVec2I(BinaryReader reader);
    public Vector2D DeserializeVec2D(BinaryReader reader);
    public Vector3 DeserializeVec3(BinaryReader reader);
    public Vector3D DeserializeVec3D(BinaryReader reader);
    public Vector4 DeserializeVec4(BinaryReader reader);
    public Vector4D DeserializeVec4D(BinaryReader reader);
    public Quaternion DeserializeQuaternion(BinaryReader reader);
    public Vector3I DeserializeVec3I(BinaryReader reader);
    public Vector4I DeserializeVec4B(BinaryReader reader);
    public QuaternionD DeserializeQuaternionD(BinaryReader reader);
}