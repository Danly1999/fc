using Godot;
using System;

[GlobalClass]
public partial class DialogueData : Resource
{
    [Export]
    public bool is_right;
    [Export]
    public Texture2D texture_rect;
    [ExportGroup("ch")]
    [Export]
    public string text_ch;
    [Export]
    public string name_ch;
    [ExportGroup("en")]
    [Export]
    public string text_en;
    [Export]
    public string name_en;
    [ExportGroup("jp")]
    [Export]
    public string name_jp;
    [Export]
    public string text_jp;
}
