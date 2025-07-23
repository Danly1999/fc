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
    public RichTextLabel text_label;
    [Export]
    public TextureRect portrait_left;
    [Export]
    public TextureRect portrait_right;
    [Export]
    public Control check_box;
    [Export] public AudioStreamPlayer TypeSound;
    [Export] public float Duration = 0.4f;
    private Tween _tween;
    private string _fullText = "";
    private int text_index = 0;
    private int _totalCharacters = 0;
    public override void _Ready()
    {
        text_label.BbcodeEnabled = true;
        text_index = 0;
        check_box.GuiInput += OnGuiInput;
        CreateDialogue();
        
        VisibilityChanged += VisibleDialogue;
    }
    private void CreateDialogue()
    {
        name_label.Text = dialogue_data.dialogue_data[text_index].name;
        text_label.Text = dialogue_data.dialogue_data[text_index].text;
        _fullText = Tr(dialogue_data.dialogue_data[text_index].text);
        text_label.Text = _fullText;
        text_label.VisibleCharacters = 0;
        _totalCharacters = text_label.GetParsedText().Length;
        _tween = CreateTween();
        _tween.TweenMethod(
            Callable.From<int>(UpdateVisibleCharacters),
            0,
            _totalCharacters,
            _totalCharacters*0.06f
        );

        portrait_right.Visible = dialogue_data.dialogue_data[text_index].is_right;
        portrait_left.Visible = !dialogue_data.dialogue_data[text_index].is_right;
        if (dialogue_data.dialogue_data[text_index].is_right)
        {
            portrait_right.Texture = dialogue_data.dialogue_data[text_index].texture_rect;
        }
        else
        {
            portrait_left.Texture = dialogue_data.dialogue_data[text_index].texture_rect;
        }
    }
    public void VisibleDialogue()
    {
        if(Visible)
        {
            text_index = 0;
        }else
        {
            
        }
    }
    private void OnGuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && Visible)
        {
            if(_tween.IsRunning())
            {
                _tween.Stop();
                text_label.VisibleCharacters = -1;
                return;
            }
            if(text_index < dialogue_data.dialogue_data.Count - 1)
            {
                text_index++;
                CreateDialogue();
            }
            else
            {
                Visible = false;
                GD.Print("DialogueManager is not visible");
            }
        }
    }


    private void UpdateVisibleCharacters(int count)
    {
        text_label.VisibleCharacters = count;
    }
}
