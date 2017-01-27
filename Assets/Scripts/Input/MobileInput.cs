using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputData))]
public class MobileInput : MonoBehaviour {

    public GameObject buttons;

    EventTrigger leftButton, rightButton, upButton, teleButton;

    InputData id;

    bool left, up, right, click = false;

    void Start() {
        id = GetComponent<InputData>();

        leftButton = buttons.transform.FindChild("leftButton").GetComponent<EventTrigger>();
        rightButton = buttons.transform.FindChild("rightButton").GetComponent<EventTrigger>();
        upButton = buttons.transform.FindChild("jumpButton").GetComponent<EventTrigger>();
        teleButton = buttons.transform.FindChild("jumpButton").GetComponent<EventTrigger>();

        SetupButtons();
    }

    void Update() {
        id.leftArrow = left;
        id.rightArrow = right;
        id.upArrow = up;

        if (Input.GetMouseButtonDown(0)) {
            //if (Input.touchCount >= 2) {
            Touch[] touches = Input.touches;

            foreach (Touch touch in touches) {
                Vector3 touchPosGUI = GUIUtility.ScreenToGUIPoint(touch.position);

                /*bool touchButtons = Utils.Contains(leftButton.GetComponent<RectTransform>(), touchPosGUI) ||
                                    Utils.Contains(rightButton.GetComponent<RectTransform>(), touchPosGUI) ||
                                    Utils.Contains(upButton.GetComponent<RectTransform>(), touchPosGUI);*/

                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId) && touch.phase == TouchPhase.Began) {
                    id.click = true;
                    id.mousePos = touch.position;
                }
                //}

            }/* else {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosGUI = GUIUtility.ScreenToGUIPoint(touch.position);

                bool touchButtons = Utils.Contains(leftButton.GetComponent<RectTransform>(), touchPosGUI) ||
                                    Utils.Contains(rightButton.GetComponent<RectTransform>(), touchPosGUI) ||
                                    Utils.Contains(upButton.GetComponent<RectTransform>(), touchPosGUI);
                // && touch.phase != TouchPhase.Began
                if (!touchButtons) {
                    id.click = true;
                    id.mousePos = Input.mousePosition;
                }
            }*/
        }
    }

    public void LeftDown(BaseEventData baseEvent) {
        left = true;
    }

    public void LeftUp(BaseEventData baseEvent) {
        left = false;
    }

    public void RightDown(BaseEventData baseEvent) {
        right = true;
    }

    public void RightUp(BaseEventData baseEvent) {
        right = false;
    }

    public void UpDown(BaseEventData baseEvent) {
        up = true;
    }

    public void UpUp(BaseEventData baseEvent) {
        up = false;
    }

    void SetupButtons() {
        EventTrigger.Entry leftDown = new EventTrigger.Entry();
        EventTrigger.Entry leftUp = new EventTrigger.Entry();

        EventTrigger.Entry rightDown = new EventTrigger.Entry();
        EventTrigger.Entry rightUp = new EventTrigger.Entry();

        EventTrigger.Entry upDown = new EventTrigger.Entry();
        EventTrigger.Entry upUp = new EventTrigger.Entry();

        EventTrigger.Entry teleDown = new EventTrigger.Entry();
        EventTrigger.Entry teleUp = new EventTrigger.Entry();

        leftDown.eventID = EventTriggerType.PointerDown;
        leftDown.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> l_callback1 = new UnityAction<BaseEventData>(LeftDown);
        leftDown.callback.AddListener(l_callback1);
        leftButton.triggers.Add(leftDown);

        leftUp.eventID = EventTriggerType.PointerUp;
        leftUp.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> l_callback2 = new UnityAction<BaseEventData>(LeftUp);
        leftUp.callback.AddListener(l_callback2);
        leftButton.triggers.Add(leftUp);

        rightDown.eventID = EventTriggerType.PointerDown;
        rightDown.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> l_callback3 = new UnityAction<BaseEventData>(RightDown);
        rightDown.callback.AddListener(l_callback3);
        rightButton.triggers.Add(rightDown);

        rightUp.eventID = EventTriggerType.PointerUp;
        rightUp.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> l_callback4 = new UnityAction<BaseEventData>(RightUp);
        rightUp.callback.AddListener(l_callback4);
        rightButton.triggers.Add(rightUp);

        upDown.eventID = EventTriggerType.PointerDown;
        upDown.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> l_callback5 = new UnityAction<BaseEventData>(UpDown);
        upDown.callback.AddListener(l_callback5);
        upButton.triggers.Add(upDown);

        upUp.eventID = EventTriggerType.PointerUp;
        upUp.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> l_callback6 = new UnityAction<BaseEventData>(UpUp);
        upUp.callback.AddListener(l_callback6);
        upButton.triggers.Add(upUp);
    }
}
