using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelData : MonoBehaviour {

    [SerializeField]
    string nextLevel = "";

    [SerializeField]
    int maxTeleports, maxScore = 1;

    [SerializeField]
    Animator winscreen;
    
    [SerializeField]
    Animator stars;

    [SerializeField]
    Button nextLevelButton;

    [SerializeField]
    Text scoretext;

    PlayerTeleport playerTeleport;

    public int MaxTeleports {
        get { return maxTeleports; }
    }

    public int MaxScore {
        get { return maxScore; }
    }

    public void GameOver() {
        if (!winscreen.GetBool("GameOver")) {
            // Make win screen go down and tell scores.

            float[] scores = Tools.CalcScore(playerTeleport.TeleportsUsed, maxTeleports, maxScore);

            scoretext.text = "Your score was " + Mathf.RoundToInt(scores[0]) + "\n You've used " + playerTeleport.TeleportsUsed  + " out of " + maxTeleports + " teleports.";

            int starsGained;

            if (scores[1] <= 50) {
                starsGained = 3;
            } else if (scores[1] <= 55) {
                starsGained = 2;
            } else if (scores[1] <= 100) {
                starsGained = 1;
            } else {
                starsGained = 0;
            }// If more than 100% of budget used.
            // The user will not get ANY stars.

            if (starsGained == 3) {
                scoretext.text = scoretext.text + "\n You got three stars, good job!";
            } else if (starsGained == 2) {
                scoretext.text = scoretext.text + "\n You got two stars, nice!";
            } else if (starsGained == 1) {
                scoretext.text = scoretext.text + "\n You got one star, close!";
            } else {
                scoretext.text = scoretext.text + "\n You didn't get any stars, \n to continue atleast gain one star.";
            }

            if (starsGained >= 1) {
                nextLevelButton.interactable = true;
            } else {
                nextLevelButton.interactable = false;
            }

            winscreen.SetBool("GameOver", true);

            StartCoroutine(StarAnimTrigger(starsGained));
        }
    }

    void Start() {
        playerTeleport = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTeleport>();

        bool valueCheck = nextLevel == "" || 
                          maxTeleports <= 0 || 
                          maxScore <= 0 || 
                          SceneManager.GetSceneByName(nextLevel).IsValid() ||
                          playerTeleport == null;

        if (valueCheck) {
            Debug.LogError("Invalid value entered.");
        }
    }

    public void NextLevel() {
        Tools.LoadLevel(nextLevel);
    }

    public void RetryLevel() {
        Tools.ReloadLevel();
    }

    IEnumerator StarAnimTrigger(int starsGained) {
        while (!winscreen.GetCurrentAnimatorStateInfo(0).IsName("DownIdle")) {
            yield return new WaitForSeconds(0.1f);
        }

        if (winscreen.GetCurrentAnimatorStateInfo(0).IsName("DownIdle")) {
            stars.SetInteger("stars", starsGained);
        }
    }
}
