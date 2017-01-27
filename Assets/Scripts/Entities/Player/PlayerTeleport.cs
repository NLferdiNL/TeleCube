using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputData))]
public class PlayerTeleport : PlayerTeleportData {

    public int TeleportsUsed {
        get {
            return teleportsUsed;
        }
    }

    void Awake() {
        tf = GetComponent<Transform>();
        id = GetComponent<InputData>();
        cam = Camera.main;

        Vector3 playerPos = tf.position;
        playerPos.x = cam.transform.position.x;
        playerPos.y = cam.transform.position.y;
        cameraDistance = Vector3.Distance(playerPos, cam.transform.position);

        //playerLayerMaskInt = gameObject.layer;
        
    }

    void Update() {
        #if UNITY_STANDALONE || UNITY_EDITOR
        if (id.mouseMove) {
            UpdateTelePath();
        }
        #endif

        if (id.click) {
            Teleport();
        }
    }

    void Teleport() {
        if (Application.platform == RuntimePlatform.Android) {
            id.click = false;
            Vector3 mousePosRaw = Input.mousePosition;
            mousePosRaw.z = cameraDistance;

            mouseToWorld = cam.ScreenToWorldPoint(mousePosRaw);
            mouseToWorld.z = tf.position.z;

            RaycastHit2D hit = Physics2D.Linecast(tf.position, mouseToWorld, wallLayer);

            if (!hit && teleportReady) {
                TriggerCooldown();
                SpawnEffect(tf.position);
                tf.position = mouseToWorld;
                teleportsUsed++;
            }
        } else {
            if (freeTelePath) {
                TriggerCooldown();
                freeTelePath = false;
                SpawnEffect(tf.position);
                tf.position = mouseToWorld;
                teleportsUsed++;
            }
        }
    
    }

    void SpawnEffect(Vector3 pos) {
        GameObject newEffect = Instantiate(teleportEffect);
        newEffect.transform.position = pos;
    }

    void UpdateTelePath() {
        Vector3 mousePosRaw = id.mousePos;
        mousePosRaw.z = cameraDistance;

        mouseToWorld = cam.ScreenToWorldPoint(mousePosRaw);
        mouseToWorld.z = tf.position.z;

        RaycastHit2D hit = Physics2D.Linecast(tf.position, mouseToWorld, wallLayer);

        if (!hit && teleportReady) {
            freeTelePath = true;
        } else {
            freeTelePath = false;
        }
    }

    void TriggerCooldown() {
        teleportReady = false;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(teleportCooldownTimer);
        teleportReady = true;
    }
}
