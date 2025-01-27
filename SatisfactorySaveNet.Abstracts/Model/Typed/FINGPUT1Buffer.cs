using SatisfactorySaveNet.Abstracts.Maths.Vector;
using System.Collections.Generic;

namespace SatisfactorySaveNet.Abstracts.Model.Typed;

public class FINGPUT1Buffer : TypedData
{
    public override TypedDataConstraint Type => TypedDataConstraint.FINGPUT1Buffer;

    public Vector2I Vector { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TypeName {  get; set; } = string.Empty;
    public int Length { get; set; }
    public ICollection<FINGPUT1BufferPixel> Buffer { get; set; } = [];
    public string Unknown { get; set; } = string.Empty;
}
