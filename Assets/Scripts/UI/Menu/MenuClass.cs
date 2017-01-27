using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClass : MonoBehaviour {

    [SerializeField]
    Transform mainMenu, optionsMenu, levelSelect;

    int currentMenu = 0;

    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void PlayButtonDown() {
        if(PlayerPrefs.HasKey("lastLevel")) {
            string lastLevel = PlayerPrefs.GetString("lastLevel");
            Tools.LoadLevel(lastLevel);
        } else {
            Tools.LoadLevel("level01");
        }
    }

    public void LVLSelectButtonDown() {
        currentMenu = 2;
        animator.SetBool("LVLSelectActive", true);
    }

    public void OptionsButtonDown() {
        currentMenu = 1;
        animator.SetBool("OptionsActive", true);
    }

    public void QuitButtonDown() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void BackButtonDown() {
        switch (currentMenu) {
            case 1:
                animator.SetBool("OptionsActive", false);
                currentMenu = 0;
                break;
            case 2:
                animator.SetBool("LVLSelectActive", false);
                currentMenu = 0;
                break;
        }
    }
}
