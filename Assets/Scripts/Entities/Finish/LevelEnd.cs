using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    LevelData data;

    [SerializeField]
    LayerMask player;

    void Start() {
        data = Camera.main.GetComponent<LevelData>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player") {
            other.GetComponent<PlayerMovement>().enabled = false;
            other.GetComponent<PlayerTeleport>().enabled = false;
            data.GameOver();
        }
    }

}
