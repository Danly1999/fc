using Godot;
using System;

[GlobalClass]
public partial class DialogueArrayData : Resource
{
    [Export]
    public Godot.Collections.Array<DialogueData> dialogue_data;

}
