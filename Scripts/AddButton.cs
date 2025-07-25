using Godot;
using System;

public partial class AddButton : BaseButton
{
	public override void _Ready()
	{
		Pressed += OnButtonPressed;
		ButtonUp += OnButtonUp;
		ButtonDown += OnButtonDown;
	}
	// 记得在节点退出时解绑事件
	public override void _ExitTree()
	{
		Pressed -= OnButtonPressed;
		ButtonUp -= OnButtonUp;
		ButtonDown -= OnButtonDown;
	}

	private void OnButtonPressed()
	{
		GameManager.Instance.playerData.hp = GameManager.Instance.playerData.hp-1;
	}

	private void OnButtonUp()
	{
		// 按钮释放时的处理逻辑
	}

	private void OnButtonDown()
	{
		// 按钮按下时的处理逻辑
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
