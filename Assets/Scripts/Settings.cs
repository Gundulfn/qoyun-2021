using UnityEngine;
using System.Collections.Generic;

/*
    Note: This script made for custom key settings, it will be add to the game later
*/

public enum KeybindAction
{
    Empty, 
    MoveForward, MoveBackward, MoveLeft, MoveRight, Jump,
    ThrowTeleportDevice, TeleportToDevice, 
    GadgetUIButton, MenuButton, 
    MuteAudio, MuteSpeech,
    Interact
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
        {KeybindAction.MoveBackward, KeyCode.S},      {KeybindAction.TeleportToDevice, KeyCode.Mouse1},
        {KeybindAction.MoveLeft, KeyCode.A},          {KeybindAction.GadgetUIButton, KeyCode.Q},
        {KeybindAction.MoveRight, KeyCode.D},         {KeybindAction.MenuButton, KeyCode.Escape},          
        {KeybindAction.Jump, KeyCode.Space},          {KeybindAction.Interact, KeyCode.E},
        {KeybindAction.MuteAudio, KeyCode.N},         {KeybindAction.MuteSpeech, KeyCode.M}
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