using UnityEngine;
using In = UnityEngine.Input;
using Kc = UnityEngine.KeyCode;

[RequireComponent(typeof(InputData))]
public class KeyboardInput : MonoBehaviour {

    InputData id;

    void Awake() {
        id = GetComponent<InputData>();
    }

    void Update() {
        id.click = id.leftArrow = id.rightArrow = id.upArrow = id.downArrow = false;

        id.mouseMove = Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0;

        if (id.mouseMove) {
            id.mousePos = Input.mousePosition;
        }

        id.click = In.GetMouseButtonDown(0);
        id.leftArrow = In.GetKey(Kc.LeftArrow) || In.GetKey(Kc.A);
        id.rightArrow = In.GetKey(Kc.RightArrow) || In.GetKey(Kc.D);
        id.upArrow = In.GetKey(Kc.UpArrow) || In.GetKey(Kc.W) || In.GetKey(Kc.Space);
        id.downArrow = In.GetKey(Kc.DownArrow) || In.GetKey(Kc.S);
    }
}
