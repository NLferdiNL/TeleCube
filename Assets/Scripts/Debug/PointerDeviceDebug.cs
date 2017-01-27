using UnityEngine;

public class PointerDeviceDebug : MonoBehaviour {

    public Vector3 MousePos, ScreenPoint;

    void Update() {
        MousePos = Input.mousePosition;
        ScreenPoint = GUIUtility.ScreenToGUIPoint(Input.mousePosition);
    }

}
