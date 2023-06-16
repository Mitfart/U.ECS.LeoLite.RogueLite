using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Lab {
  public static class MouseUtils {
    public static Vector2 Pos() {
      Vector2 pos;
#if ENABLE_INPUT_SYSTEM
      pos = Mouse.current.position.ReadValue();
#elif ENABLE_LEGACY_INPUT_MANAGER
			pos = Input.mousePosition;
#endif
      return pos;
    }

    public static Vector2 WorldPos2D(Camera camera = null) {
      camera ??= Camera.main;
      if (camera == null)
        throw new Exception("Camera no set!");

      return camera.ScreenToWorldPoint(Pos());
    }

    public static Vector3 WorldPos3D(Camera camera = null, LayerMask layerMask = default) {
      camera ??= Camera.main;
      if (camera == null)
        throw new Exception("Camera no set!");

      Ray ray = camera.ScreenPointToRay(Pos());
      UnityEngine.Physics.Raycast(ray, out RaycastHit hit, layerMask);
      return hit.point;
    }



    public static bool LeftBtn() {
#if ENABLE_INPUT_SYSTEM
      return Mouse.current.leftButton.isPressed;
#elif ENABLE_LEGACY_INPUT_MANAGER
			return Input.GetKey(KeyCode.Mouse0);
#endif
    }

    public static bool RightBtn() {
#if ENABLE_INPUT_SYSTEM
      return Mouse.current.rightButton.isPressed;
#elif ENABLE_LEGACY_INPUT_MANAGER
			return Input.GetKey(KeyCode.Mouse1);
#endif
    }


    public static bool LeftBtnDown() {
#if ENABLE_INPUT_SYSTEM
      return Mouse.current.leftButton.wasPressedThisFrame;
#elif ENABLE_LEGACY_INPUT_MANAGER
			return Input.GetKeyDown(KeyCode.Mouse0);
#endif
    }

    public static bool RightBtnDown() {
#if ENABLE_INPUT_SYSTEM
      return Mouse.current.rightButton.wasPressedThisFrame;
#elif ENABLE_LEGACY_INPUT_MANAGER
			return Input.GetKeyDown(KeyCode.Mouse1);
#endif
    }


    public static bool LeftBtnUp() {
#if ENABLE_INPUT_SYSTEM
      return Mouse.current.leftButton.wasReleasedThisFrame;
#elif ENABLE_LEGACY_INPUT_MANAGER
			return Input.GetKeyUp(KeyCode.Mouse0);
#endif
    }

    public static bool RightBtnUp() {
#if ENABLE_INPUT_SYSTEM
      return Mouse.current.rightButton.wasReleasedThisFrame;
#elif ENABLE_LEGACY_INPUT_MANAGER
			return Input.GetKeyUp(KeyCode.Mouse1);
#endif
    }
  }
}