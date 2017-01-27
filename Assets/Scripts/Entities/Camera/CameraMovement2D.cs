using UnityEngine;

public class CameraMovement2D : MonoBehaviour {

    [SerializeField, Tooltip("The target the camera will follow.")]
    Transform target;

    [SerializeField, Tooltip("Where the target will be, defaults to center.")]
    Vector2 offset = new Vector2(0,5);

    [SerializeField, Tooltip("Approximately the time it will take to reach the target. A smaller value will reach the target faster.")]
    float smoothTime = 0.3f;

    Transform tf;

    Vector3 velocity = Vector3.zero;

    void Awake() {
        tf = GetComponent<Transform>();
    }

    void Update() {
        Vector3 targetPos = (Vector2)target.position + offset;
        targetPos.z = tf.position.z;

        tf.position = Vector3.SmoothDamp(tf.position, targetPos, ref velocity, smoothTime);
    }

}
