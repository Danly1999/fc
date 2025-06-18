using Godot;
using System;

public static class GameMamager
{
    public static Action<float> action;
    public static void Rise(float value)
    {
        action.Invoke(value);
        
    }
}
