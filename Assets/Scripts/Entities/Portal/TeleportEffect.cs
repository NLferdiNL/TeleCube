using UnityEngine;

public class TeleportEffect : MonoBehaviour {

    Animator animator;
    AudioSource teleportSfx;

    /*Light glow;
    Transform tf;

    bool disappearing = false;

    [SerializeField]
    float time = 0;

    [SerializeField]
    Vector3 growTo = new Vector3(0.6f, 0.6f, 1);

    [SerializeField]
    Vector3 shrinkTo = new Vector3(0, 0, 1);

    [SerializeField]
    float effectSpeed = 0.5f;*/

    void Start() {
        //glow = GetComponent<Light>();
        //tf = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        teleportSfx = GetComponent<AudioSource>();
    }

    void Update() {
        /*
        if (!disappearing) {
            tf.localScale = Vector3.Lerp(tf.localScale, growTo, time);
            glow.range = tf.localScale.x * 3.5f;
            time += Time.deltaTime * effectSpeed;
            if (time >= 1) {
                disappearing = true;
                time = 0;
            }
        } else {
            tf.localScale = Vector3.Lerp(tf.localScale, shrinkTo, time);
            glow.range = tf.localScale.x * 3.5f;
            time += Time.deltaTime * effectSpeed;
            if (time >= 1) {
                Destroy(gameObject);
            }
        }*/

        // It was stupid of me to even try animations in code when I could just do it here
        // using Unity's animation system.

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AfterIdle") && !teleportSfx.isPlaying) {
            Destroy(gameObject);
        }
    }
}
