using UnityEngine;

public class RotatingObject : MonoBehaviour {

    Transform tf;

    [SerializeField]
    Vector3 rotation = new Vector3(0, 1, 0);

    [SerializeField]
    float angle = 1;

    void Start() {
        tf = GetComponent<Transform>();
    }

    void Update() {
        tf.Rotate(rotation, angle);
    }
}
