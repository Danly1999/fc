using Godot;
using System;
using System.Collections;

public partial class DialogueManager : Control
{
    [Export]
    public DialogueArrayData dialogue_data;
    [Export]
    public Label name_label;
    [Export]
    public Label text_label;
    [Export]
    public TextureRect portrait_left;
    [Export]
    public TextureRect portrait_right;
    [Export]
    public Control check_box;
    [Export] public AudioStreamPlayer TypeSound;
    [Export] public float Duration = 2.0f;
    private Tween _tween;
    private string _fullText = "";
    private int _lastCharCount = 0;
    public override void _Ready()
    {
        check_box.GuiInput += OnGuiInput;
        CreateDialogue();
    }
    private void CreateDialogue()
    {
        name_label.Text = dialogue_data.dialogue_data[0].name;
        text_label.Text = dialogue_data.dialogue_data[0].text;

        portrait_right.Visible = dialogue_data.dialogue_data[0].is_right;
        portrait_left.Visible = !dialogue_data.dialogue_data[0].is_right;
        if (dialogue_data.dialogue_data[0].is_right)
        {
            portrait_right.Texture = dialogue_data.dialogue_data[0].texture_rect;
        }
        else
        {
            portrait_left.Texture = dialogue_data.dialogue_data[0].texture_rect;
        }
    }

    private void OnGuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            GD.Print("Control被左键点击了!");
        }
    }
        private void StartTypewriterEffect()
    {
        _tween = CreateTween();
        _tween.TweenMethod(
            Callable.From<int>(UpdateVisibleCharacters),
            0,
            _fullText.Length,
            Duration
        );
    }

    private void UpdateVisibleCharacters(int count)
    {
        text_label.Text = _fullText.Substring(0, count);
        
        // 当有新字符出现时播放音效
        if (count > _lastCharCount && TypeSound != null)
        {
            TypeSound.PitchScale = GD.Randf() * 0.2f + 0.9f; // 随机音高
            TypeSound.Play();
        }
        
        _lastCharCount = count;
    }
}
