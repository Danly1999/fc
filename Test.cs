using Godot;
using System;

public partial class Test : Node
{
    public override void _Ready()
    {
        GameMamager.action += PrintValue;
        GameMamager.Rise(10);
    }
    public void PrintValue(float value)
    {
        GD.Print(value);
    }
}
