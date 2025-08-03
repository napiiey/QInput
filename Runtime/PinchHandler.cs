using UnityEngine;
using UnityEngine.InputSystem;

namespace Acfeel.QuickInput
{
    public static class PinchHandler
    {
        public static float PinchUpdate()
        {
            if (Touchscreen.current == null || Touchscreen.current.touches.Count < 2) { return 0f; }

            float distance = Vector2.Distance(Touchscreen.current.touches[0].position.ReadValue(),
                                              Touchscreen.current.touches[1].position.ReadValue());

            if (!InputState.IsPinching && Touchscreen.current.touches[0].press.isPressed && Touchscreen.current.touches[1].press.isPressed)
            {
                InputState.IsPinching = true;
                InputState.BasePinchDistance = distance;
            }
            else if (InputState.IsPinching && (!Touchscreen.current.touches[0].press.isPressed || !Touchscreen.current.touches[1].press.isPressed))
            {
                InputState.IsPinching = false;
            }

            if (!InputState.IsPinching) return 0f;

            float result = distance - InputState.BasePinchDistance;
            InputState.BasePinchDistance = distance;
            return result;
        }

        public static bool IsPinching()
        {
            return InputState.IsPinching;
        }
    }
}
