using Godot;
using System;
public enum SaveType
{
    Save,
    Load
}
public partial class SaveButton : Button
{
    [Export]
    public SaveType saveType;
    public override void _Ready()
    {
        Pressed += OnButtonPressed;
    }
    // 记得在节点退出时解绑事件
    public override void _ExitTree()
    {
        Pressed -= OnButtonPressed;
    }
    private void OnButtonPressed()
	{
        string path = ProjectSettings.GlobalizePath("user://save.tres");
        if (saveType == SaveType.Save)
        {
            GameManager.Instance.SaveToJson(path);
        }
        else
        {
            GameManager.Instance.LoadFromJson(path);
        }
	}
}
