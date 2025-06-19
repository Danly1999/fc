using Godot;
using System;

public class GameMamager
{
    private static GameMamager _instance;
    public static GameMamager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameMamager();
            }
            return _instance;
        }
    }
    private float _hp = 100;
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

    // 私有构造函数，防止外部实例化
    private GameMamager() {}

    public void Rise_hp(float value)
    {
        Instance.action_hp?.Invoke(value);
    }
}
