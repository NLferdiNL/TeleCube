using UnityEngine;

public class PlayerTeleportData : MonoBehaviour {
    [SerializeField]
    protected LayerMask wallLayer;

    protected bool freeTelePath = false; // If true, the mouse is at a position from which it can teleport.
    protected Transform tf;
    protected InputData id;
    protected Camera cam;
    protected float cameraDistance;
    protected Vector3 mouseToWorld;

    [SerializeField]
    protected GameObject teleportEffect;

    protected int teleportsUsed = 0;

    [SerializeField, Tooltip("The time it takes to cooldown the teleport.")]
    protected float teleportCooldownTimer = 1;

    protected bool teleportReady = true;
}
