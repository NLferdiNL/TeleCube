using UnityEngine;

public class PersistantChildren : MonoBehaviour {

    // Made this before I realized children of a persistant object
    // automaticly inherit that power.

    void Awake() {
        int children = transform.childCount;

        for (int i = 0; i < children; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            DontDestroyOnLoad(child);
        }
    }
}
