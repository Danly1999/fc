using Godot;
using System;

[GlobalClass]
public partial class PlayerData : Resource
{
    [Export]
    public float money;
    [Export]
    public float score;
    [Export]
    public float time;
    public void DataLoad(PlayerData data)
    {
        hp = data.hp;
        money = data.money;
        score = data.score;
        time = data.time;
    }
    private float _hp = 100;
    [Export]
    public float hp{
        get{
            return _hp;
        }
        set{
            _hp = value;
            Rise_hp(value);
        }
    }
    public Action<float> action_hp;
    public void Rise_hp(float value)
    {
        action_hp?.Invoke(value);
    }
}
