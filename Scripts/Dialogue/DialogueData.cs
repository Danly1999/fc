using Godot;
using System;

[GlobalClass]
public partial class DialogueData : Resource
{
    [Export]
    public bool is_right;
    [Export]
    public Texture2D texture_rect;
    [Export]
    public string name;
    [Export]
    public string text;
}
