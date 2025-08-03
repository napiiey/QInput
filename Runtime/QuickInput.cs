using UnityEngine;
using UnityEngine.InputSystem;

namespace Acfeel.QuickInput
{
    public static class QuickInput
    {
        // Flick Properties
        public static bool IsFlicking => InputState.IsFlicking;
        public static Vector2 FlickStartPosition => InputState.FlickStartPosition;
        public static Vector2 FlickEndPosition => InputState.FlickEndPosition;
        public static Vector2 FlickDistance => InputState.FlickDistance;
        public static int FlickTime => InputState.FlickTime;

        // Ok / Confirm
        public static bool OkDown()
        {
            return Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        }

        public static bool OkDownCt(int ct = 1)
        {
            if (OkDown() && InputState.ClickCt >= ct) { InputState.ClickCt = 0; return true; }
            return false;
        }

        public static bool Ok()
        {
            return Gamepad.current != null && Gamepad.current.buttonSouth.isPressed
            || Keyboard.current != null && Keyboard.current.enterKey.isPressed
            || Keyboard.current != null && Keyboard.current.spaceKey.isPressed;
        }

        public static bool OkClickDown()
        {
            return OkDown()
            || Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame
            || Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;
        }

        public static bool OkClick()
        {
            return Ok()
            || Mouse.current != null && Mouse.current.leftButton.isPressed
            || Touchscreen.current != null && Touchscreen.current.touches.Count > 0 && Touchscreen.current.touches[0].press.isPressed;
        }

        // Click / Touch
        public static bool ClickDown()
        {
            return Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame
            || Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;
        }

        public static bool ClickUp()
        {
            return Mouse.current != null && Mouse.current.leftButton.wasReleasedThisFrame
            || Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasReleasedThisFrame;
        }

        public static bool Click()
        {
            return Mouse.current != null && Mouse.current.leftButton.isPressed
            || Touchscreen.current != null && Touchscreen.current.touches.Count > 0 && Touchscreen.current.touches[0].press.isPressed;
        }

        public static Vector2 ClickPosition()
        {
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
            {
                return Touchscreen.current.position.ReadValue();
            }
            if (Mouse.current != null)
            {
                return Mouse.current.position.ReadValue();
            }
            return Vector2.zero;
        }

        // Cancel
        public static bool CancelDown()
        {
            return Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame
            || Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame;
        }

        public static bool CancelDownCt(int ct = 1)
        {
            if (CancelDown() && InputState.ClickCt >= ct) { InputState.ClickCt = 0; return true; }
            return false;
        }

        public static bool Cancel()
        {
            return Gamepad.current != null && Gamepad.current.buttonEast.isPressed
            || Keyboard.current != null && Keyboard.current.escapeKey.isPressed;
        }

        public static bool CancelClickDown()
        {
            return CancelDown()
            || Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame
            || Touchscreen.current != null && Touchscreen.current.touches.Count > 1 && Touchscreen.current.touches[1].press.wasPressedThisFrame;
        }

        public static bool CancelClick()
        {
            return Cancel()
            || Mouse.current != null && Mouse.current.rightButton.isPressed
            || Touchscreen.current != null && Touchscreen.current.touches.Count > 1 && Touchscreen.current.touches[1].press.isPressed;
        }

        // Mouse Specific
        public static bool LeftClickDown()
        {
            return Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
        }

        public static bool LeftClick()
        {
            return Mouse.current != null && Mouse.current.leftButton.isPressed;
        }

        public static bool RightClickDown()
        {
            return Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame;
        }

        public static bool RightClick()
        {
            return Mouse.current != null && Mouse.current.rightButton.isPressed;
        }

        public static float WheelScroll()
        {
            if (Mouse.current == null) { return 0; }
            return Mouse.current.scroll.ReadValue().y;
        }

        public static bool WheelUp()
        {
            return Mouse.current != null && Mouse.current.scroll.ReadValue().y > 0;
        }

        public static bool WheelDown()
        {
            return Mouse.current != null && Mouse.current.scroll.ReadValue().y < 0;
        }

        // Directional
        public static bool UpDown() => DirectionalInputHandler.UpDown();
        public static bool DownDown() => DirectionalInputHandler.DownDown();
        public static bool LeftDown() => DirectionalInputHandler.LeftDown();
        public static bool RightDown() => DirectionalInputHandler.RightDown();
        public static bool UpUp() => DirectionalInputHandler.UpUp();
        public static bool DownUp() => DirectionalInputHandler.DownUp();
        public static bool LeftUp() => DirectionalInputHandler.LeftUp();
        public static bool RightUp() => DirectionalInputHandler.RightUp();
        public static bool Up() => DirectionalInputHandler.Up();
        public static bool Down() => DirectionalInputHandler.Down();
        public static bool Left() => DirectionalInputHandler.Left();
        public static bool Right() => DirectionalInputHandler.Right();
        public static bool UpRepeated() => DirectionalInputHandler.UpRepeated();
        public static bool DownRepeated() => DirectionalInputHandler.DownRepeated();
        public static bool LeftRepeated() => DirectionalInputHandler.LeftRepeated();
        public static bool RightRepeated() => DirectionalInputHandler.RightRepeated();
        public static bool UdlrDown() => UpDown() || DownDown() || LeftDown() || RightDown();
        public static bool UdlrUp() => UpUp() || DownUp() || LeftUp() || RightUp();
        public static bool Udlr() => Up() || Down() || Left() || Right();
        public static Vector2 Direction() => DirectionalInputHandler.Direction();
        public static Vector3 Movement() => new Vector3(Direction().x, 0f, Direction().y);
        public static float GetAxisHorizontal() => Direction().x;
        public static float GetAxisVertical() => Direction().y;

        // Gamepad Buttons
        public static bool NorthDown() => Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame;
        public static bool SouthDown() => Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame;
        public static bool EastDown() => Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame;
        public static bool WestDown() => Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame;
        public static bool LeftShoulderDown() => Gamepad.current != null && Gamepad.current.leftShoulder.wasPressedThisFrame;
        public static bool RightShoulderDown() => Gamepad.current != null && Gamepad.current.rightShoulder.wasPressedThisFrame;
        public static bool LeftTriggerDown() => Gamepad.current != null && Gamepad.current.leftTrigger.wasPressedThisFrame;
        public static bool RightTriggerDown() => Gamepad.current != null && Gamepad.current.rightTrigger.wasPressedThisFrame;

        // Screen Pad
        public static void ScreenPadUDown() => ScreenPadHandler.ScreenPadUDown();
        public static void ScreenPadDDown() => ScreenPadHandler.ScreenPadDDown();
        public static void ScreenPadLDown() => ScreenPadHandler.ScreenPadLDown();
        public static void ScreenPadRDown() => ScreenPadHandler.ScreenPadRDown();
        public static void ScreenPadUUp() => ScreenPadHandler.ScreenPadUUp();
        public static void ScreenPadDUp() => ScreenPadHandler.ScreenPadDUp();
        public static void ScreenPadLUp() => ScreenPadHandler.ScreenPadLUp();
        public static void ScreenPadRUp() => ScreenPadHandler.ScreenPadRUp();

        // Pinch
        public static float PinchUpdate() => PinchHandler.PinchUpdate();
        public static bool IsPinching() => PinchHandler.IsPinching();
    }
}

