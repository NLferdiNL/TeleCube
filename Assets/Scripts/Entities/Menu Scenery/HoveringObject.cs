using UnityEngine;

public class HoveringObject : MonoBehaviour {

    Transform tf;

    [SerializeField]
    Vector3 movementUp = new Vector3(0, 1, 0);

    [SerializeField]
    Vector3 movementDown = new Vector3(0, -1, 0);

    [SerializeField]
    Vector3 movement = new Vector3(0, 0.5f, 0);
    bool goingUp = true;

    void Start() {
        tf = GetComponent<Transform>();
        movementUp += tf.position;
        movementDown += tf.position;
    }

    void Update() {
        if(goingUp) {
            tf.position += movement;
        } else {
            tf.position -= movement;
        }

        if (tf.position.y >= movementUp.y) {
            goingUp = false;
        } else if (tf.position.y <= movementDown.y) {
            goingUp = true;
        }
    }
}
