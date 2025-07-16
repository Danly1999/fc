using Godot;
using System;
public enum QuantityType
{
    Single,
    Multiple,
    Infinite
}
[GlobalClass]
public partial class PropsData : Resource
{
    [Export]
    public string Name;

    [Export]
    public Texture2D Image;

    [Export]
    public QuantityType Quantity;

    [Export]
    public Color Color = new Color(1, 1, 1, 1);

}
