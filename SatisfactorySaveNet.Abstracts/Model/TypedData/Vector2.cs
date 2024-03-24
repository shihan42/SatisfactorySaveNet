namespace SatisfactorySaveNet.Abstracts.Model.TypedData;

public class Vector2 : TypedData
{
    public override TypedDataConstraint Type => TypedDataConstraint.Vector2;

    public Maths.Vector.Vector2 Value { get; set; }
}