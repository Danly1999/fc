using Godot;
using System;
using System.Collections;

public partial class DialogueManager : Control
{
    [Export]
    public Godot.Collections.Array<DialogueData> dialogue_data;
    [Export]
    public Label name_label;
    [Export]
    public Label text_label;
    [Export]
    public TextureRect portrait_left;
    [Export]
    public TextureRect portrait_right;

    public override void _Ready()
    {
        name_label.Text = dialogue_data[0].name;
        GD.Print(Tr(dialogue_data[0].text));
        text_label.Text = dialogue_data[0].text;

        portrait_right.Visible = dialogue_data[0].is_right;
        portrait_left.Visible = !dialogue_data[0].is_right;
        portrait_left.Texture = dialogue_data[0].texture_rect;
        portrait_right.Texture = dialogue_data[0].texture_rect;
        
    }
}
