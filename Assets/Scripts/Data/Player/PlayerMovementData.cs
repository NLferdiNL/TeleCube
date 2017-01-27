using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputData))]
public class PlayerMovementData : MonoBehaviour {

    // Using a dataclass because playermovement can get a lot of variables.

    protected Transform tf;
    protected Rigidbody2D rb;
    protected InputData id;

    [SerializeField]
    protected bool touchingGround = false;

    [SerializeField, Tooltip("How fast I will move on the ground.")]
    protected float groundMovementSpeed = 10f;

    [SerializeField, Tooltip("How fast I will move in the air.")]
    protected float airMovementSpeed = 7f;

    [SerializeField, Tooltip("How strong my jump will be.")]
    protected float jumpPower = 10;

    [SerializeField, Tooltip("In order to use whole numbers in movement which I'll divide by this number.")]
    protected float movementDivider = 30f;

    [SerializeField, Tooltip("The ground layer.")]
    protected string wallLayerName;

    protected int wallLayer;

    protected bool left, right, up, down = false;

}
