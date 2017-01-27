using UnityEngine;
using UnityEngine.UI;

public class InputTypeInitialize : MonoBehaviour {

    [SerializeField]
    GameObject mobileButtons;

    void Start() {
        if (Application.platform == RuntimePlatform.Android) {
            MobileInput mi = gameObject.AddComponent<MobileInput>();

            GameObject buttons;
            Transform canvas;
            if (GameObject.Find("Canvas") != null) {
                canvas = GameObject.Find("Canvas").transform;
            } else {
                GameObject newCanvas = new GameObject();
                canvas = newCanvas.GetComponent<Transform>();
                newCanvas.AddComponent<Canvas>();
                CanvasScaler cs = newCanvas.AddComponent<CanvasScaler>();
                newCanvas.AddComponent<GraphicRaycaster>();

                cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                cs.matchWidthOrHeight = 0.5f;
            }

            if (canvas.FindChild(mobileButtons.name) == null) {
                buttons = Instantiate(mobileButtons);
                buttons.name = mobileButtons.name;
                buttons.transform.SetParent(canvas, true);

                RectTransform rt = buttons.GetComponent<RectTransform>();
                rt.position = new Vector3(622, 0);

            } else {
                buttons = canvas.FindChild(mobileButtons.name).gameObject;
            }

            mi.buttons = buttons;
        } else {
            gameObject.AddComponent<KeyboardInput>();
        }

        Destroy(GetComponent<InputTypeInitialize>());
    }
}
