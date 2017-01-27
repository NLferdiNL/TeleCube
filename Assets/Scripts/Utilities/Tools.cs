using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Tools {

    public static int CheckValidLayerMask(string layerName) {
        int layerInt = LayerMask.NameToLayer(layerName);

        if (layerInt == -1 || layerName == "") {
            // Even though I'm working on this alone,
            // even I can be a bit of a dummy.
            Debug.LogError("Invalid LayerMask name given.");
            layerInt = -1; // Just incase a valid one was found 
                           // simply by leaving it empty.
        }
        return layerInt;
    }

    public static bool Contains(Transform A, Transform B) {
        Vector3 ObjAPosA = A.position - (A.lossyScale * 100);
        Vector3 ObjAPosB = A.position + (A.lossyScale * 100);

        bool XCheck = B.position.x > ObjAPosA.x && B.position.x < ObjAPosB.x;
        bool YCheck = B.position.y > ObjAPosA.y && B.position.y < ObjAPosB.y;

        if (XCheck && YCheck) {
            return true;
        }

        return false;
    }

    public static bool Contains(Transform A, Vector3 B) {
        Vector3 ObjAPosA = A.position - (A.lossyScale * 100);
        Vector3 ObjAPosB = A.position + (A.lossyScale * 100);

        bool XCheck = B.x > ObjAPosA.x && B.x < ObjAPosB.x;
        bool YCheck = B.y > ObjAPosA.y && B.y < ObjAPosB.y;

        //Debug.Log("The borders are: " + ObjAPosA + " and " + ObjAPosB + " | Position to evaluate is " + B + " | Results are: " + XCheck + ", " + YCheck);

        if (XCheck && YCheck) {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Returns an array containing score and percentage of total teleports used to max.
    /// </summary>
    /// <param name="teleportsUsed"></param>
    /// <param name="maxTeleports"></param>
    /// <param name="maxScore"></param>
    /// <returns></returns>
    public static float[] CalcScore(float teleportsUsed, float maxTeleports, float maxScore) {
        float[] scores = new float[2];

        if (teleportsUsed < maxTeleports) { //BONUS ZONE
            float fiftyPercent = maxScore * 0.5f;

            float belowLimitTeleports = maxTeleports - teleportsUsed;

            scores[0] = maxScore + fiftyPercent * belowLimitTeleports;


        } else { // ELSE MAX OR LESS CORE
            if (teleportsUsed == maxTeleports) {
                scores[0] = maxScore;
            } else {
                float twentyPercent = maxScore * 0.2f; // For every teleport you've used above the max
                                                    // you lose 20% of your score.

                float overLimitTeleports = teleportsUsed - maxTeleports;

                scores[0] = maxScore - twentyPercent * overLimitTeleports;
            }
        }

        // This is crappy work.
        /*if (teleportsUsed < maxTeleports) {
            if (teleportsUsed >= 1)
                scores[1] = teleportsUsed / maxTeleports * 10;
            else
                scores[1] = maxTeleports;
            scores[0] = maxScore + maxScore / scores[1];
        } else if(teleportsUsed >= maxTeleports){
            float newTeleportsUsed = teleportsUsed - maxTeleports;
            scores[1] = newTeleportsUsed / maxTeleports * 250;
            if (scores[1] > 0) {
                scores[0] = maxScore - maxScore / scores[1];
            } else {
                scores[0] = maxScore;
            }
        } */

        return scores;
    }

    public static void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadLevel(string nextLevel) {
        SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Single);
        GameObject canvas = GameObject.Find("PersistantCanvas");
    }

    /*public static LanguageClass ReturnLanguage() {
        SystemLanguage langName = Application.systemLanguage;
        LanguageClass langClass = new English();

        Debug.Log(langName.ToString());

        if (Type.GetType(langName.ToString()) != null) {
            Type langType = Type.GetType(langName.ToString());
            langClass = (LanguageClass)Activator.CreateInstance(langType);
        }

        return langClass;
    }*/ // Not used. Maybe in the future it will be.
}
