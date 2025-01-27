using SatisfactorySaveNet.Abstracts.Maths.Vector;
using System.Collections.Generic;

namespace SatisfactorySaveNet.Abstracts.Model;

public class ActorObject : ComponentObject
{
    public new const int TypeID = 1;

    public override int Type => TypeID;
    /// <summary>
    /// NeedTransform != 0 <=> True
    /// </summary>
    public int NeedTransform { get; set; }
    public Vector4 Rotation { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Scale { get; set; }
    /// <summary>
    /// PlacedInLevel != 0 <=> True
    /// </summary>
    public int PlacedInLevel { get; set; }

    public string ParentObjectRoot { get; set; } = string.Empty;
    public string ParentObjectName { get; set; } = string.Empty;
    public ICollection<ObjectReference> Components { get; set; } = [];
}