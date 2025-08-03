using UnityEngine;
using UnityEngine.InputSystem;

namespace Acfeel.QInput
{
    public static class DirectionalInputHandler
    {
        public static bool UpPressed()
        {
            return Gamepad.current != null && Gamepad.current.dpad.up.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.wKey.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.upArrowKey.wasPressedThisFrame
            || InputState.ScreenPadUDown;
        }
        public static bool DownPressed()
        {
            return Gamepad.current != null && Gamepad.current.dpad.down.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.sKey.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.downArrowKey.wasPressedThisFrame
            || InputState.ScreenPadDDown;
        }
        public static bool LeftPressed()
        {
            return Gamepad.current != null && Gamepad.current.dpad.left.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.aKey.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.leftArrowKey.wasPressedThisFrame
            || InputState.ScreenPadLDown;
        }
        public static bool RightPressed()
        {
            return Gamepad.current != null && Gamepad.current.dpad.right.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.dKey.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.rightArrowKey.wasPressedThisFrame
            || InputState.ScreenPadRDown;
        }
        public static bool UpReleased()
        {
            return Gamepad.current != null && Gamepad.current.dpad.up.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.wKey.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.upArrowKey.wasReleasedThisFrame
            || InputState.ScreenPadUUp;
        }
        public static bool DownReleased()
        {
            return Gamepad.current != null && Gamepad.current.dpad.down.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.sKey.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.downArrowKey.wasReleasedThisFrame
            || InputState.ScreenPadDUp;
        }
        public static bool LeftReleased()
        {
            return Gamepad.current != null && Gamepad.current.dpad.left.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.aKey.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.leftArrowKey.wasReleasedThisFrame
            || InputState.ScreenPadLUp;
        }
        public static bool RightReleased()
        {
            return Gamepad.current != null && Gamepad.current.dpad.right.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.dKey.wasReleasedThisFrame
            || Keyboard.current != null && Keyboard.current.rightArrowKey.wasReleasedThisFrame
            || InputState.ScreenPadRUp;
        }
        public static bool Up()
        {
            return Gamepad.current != null && Gamepad.current.dpad.up.isPressed
            || Keyboard.current != null && Keyboard.current.wKey.isPressed
            || Keyboard.current != null && Keyboard.current.upArrowKey.isPressed
            || InputState.ScreenPadU;
        }
        public static bool Down()
        {
            return Gamepad.current != null && Gamepad.current.dpad.down.isPressed
            || Keyboard.current != null && Keyboard.current.sKey.isPressed
            || Keyboard.current != null && Keyboard.current.downArrowKey.isPressed
            || InputState.ScreenPadD;
        }
        public static bool Left()
        {
            return Gamepad.current != null && Gamepad.current.dpad.left.isPressed
            || Keyboard.current != null && Keyboard.current.aKey.isPressed
            || Keyboard.current != null && Keyboard.current.leftArrowKey.isPressed
            || InputState.ScreenPadL;
        }
        public static bool Right()
        {
            return Gamepad.current != null && Gamepad.current.dpad.right.isPressed
            || Keyboard.current != null && Keyboard.current.dKey.isPressed
            || Keyboard.current != null && Keyboard.current.rightArrowKey.isPressed
            || InputState.ScreenPadR;
        }

        public static bool UpRepeated()
        {
            if (UpPressed()) { InputState.ClickCt = 0; return true; }
            if (Up() && InputState.ClickCt >= InputLoop.RepeatStart && InputState.RepeatCt >= InputLoop.RepeatDuration) { InputState.RepeatCt = 0; return true; }
            return false;
        }
        public static bool DownRepeated()
        {
            if (DownPressed()) { InputState.ClickCt = 0; return true; }
            if (Down() && InputState.ClickCt >= InputLoop.RepeatStart && InputState.RepeatCt >= InputLoop.RepeatDuration) { InputState.RepeatCt = 0; return true; }
            return false;
        }
        public static bool LeftRepeated()
        {
            if (LeftPressed()) { InputState.ClickCt = 0; return true; }
            if (Left() && InputState.ClickCt >= InputLoop.RepeatStart && InputState.RepeatCt >= InputLoop.RepeatDuration) { InputState.RepeatCt = 0; return true; }
            return false;
        }
        public static bool RightRepeated()
        {
            if (RightPressed()) { InputState.ClickCt = 0; return true; }
            if (Right() && InputState.ClickCt >= InputLoop.RepeatStart && InputState.RepeatCt >= InputLoop.RepeatDuration) { InputState.RepeatCt = 0; return true; }
            return false;
        }

        public static Vector2 Direction()
        {
            InputState.Direction.x = 0f;
            InputState.Direction.y = 0f;
            if (Keyboard.current != null && Keyboard.current.aKey.isPressed
            || Keyboard.current != null && Keyboard.current.leftArrowKey.isPressed
            || InputState.ScreenPadL)
            {
                InputState.Direction.x = -1f;
            }
            if (Keyboard.current != null && Keyboard.current.dKey.isPressed
            || Keyboard.current != null && Keyboard.current.rightArrowKey.isPressed
            || InputState.ScreenPadR)
            {
                InputState.Direction.x += 1f;
            }
            if (Keyboard.current != null && Keyboard.current.sKey.isPressed
            || Keyboard.current != null && Keyboard.current.downArrowKey.isPressed
            || InputState.ScreenPadD)
            {
                InputState.Direction.y = -1f;
            }
            if (Keyboard.current != null && Keyboard.current.wKey.isPressed
            || Keyboard.current != null && Keyboard.current.upArrowKey.isPressed
            || InputState.ScreenPadU)
            {
                InputState.Direction.y += 1f;
            }
            if (Gamepad.current != null)
            {
                InputState.Direction += Gamepad.current.leftStick.ReadValue();
            }
            InputState.Direction.Normalize();
            return InputState.Direction;
        }
    }
}
