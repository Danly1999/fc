using Godot;
using System;

public partial class LabelHP : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameMamager.Instance.action_hp += OnHpChanged;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _ExitTree()
	{
		GameMamager.Instance.action_hp -= OnHpChanged;
	}

	private void OnHpChanged(float value)
	{
		Text = $"{value}/100";
	}
}
