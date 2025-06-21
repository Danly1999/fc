using Godot;
using System;

public partial class Test : Node
{
	public override void _Ready()
	{
		// 加载资源
		PackedScene enemyScene = (PackedScene)GD.Load("res://Scenes/enemy.tscn");
		// 实例化资源
		Node enemyInstance = enemyScene.Instantiate();
		// 添加到当前节点（或其他你想要的父节点）
		AddChild(enemyInstance);

		GetNode<Label>("UI/Enemy/TextureRect/Label").Text = "Hello, World!";
	}
	public void PrintValue(float value)
	{

	}
}
