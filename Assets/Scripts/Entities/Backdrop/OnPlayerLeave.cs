using UnityEngine;

public class OnPlayerLeave : MonoBehaviour {
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            Tools.ReloadLevel();
        }
    }

}
