using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum KeybindAction
{
    Empty, 
    MoveForward, MoveBackward, MoveLeft, MoveRight, Jump,
    ThrowTeleportDevice, Teleport, 
    MenuButton, InteractionButton
}

public enum AnalogValue
{
    MouseSensivity, RotationSensivity
}

public class Settings : MonoBehaviour
{
    public static readonly Dictionary<KeybindAction, KeyCode> defaultKeys = new Dictionary<KeybindAction, KeyCode>()
    {
        {KeybindAction.MoveForward, KeyCode.W},       {KeybindAction.ThrowTeleportDevice, KeyCode.Mouse0},
        {KeybindAction.MoveBackward, KeyCode.S},      {KeybindAction.Teleport, KeyCode.Mouse1},
        {KeybindAction.MoveLeft, KeyCode.A},          {KeybindAction.MenuButton, KeyCode.Escape},
        {KeybindAction.MoveRight, KeyCode.D},         {KeybindAction.InteractionButton, KeyCode.E},          
        {KeybindAction.Jump, KeyCode.Space}
    };

    private static readonly Dictionary<AnalogValue, float> defaultAnalogValues = new Dictionary<AnalogValue, float>()
    {
        {AnalogValue.MouseSensivity, 5}, {AnalogValue.RotationSensivity, 10}
    };

    // Get keys and values functions
    public static KeyCode GetKeyCode(KeybindAction keybindAction)
    {
        return defaultKeys[keybindAction];
    }

    public static float GetAnalogValue(AnalogValue analogValue)
    {
        return defaultAnalogValues[analogValue];
    }
}