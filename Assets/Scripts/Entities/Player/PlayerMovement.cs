using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : PlayerMovementData {

    void Awake() {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        id = GetComponent<InputData>();

        wallLayer = LayerMask.NameToLayer(wallLayerName);
    }

    void FixedUpdate() {
        UpdateMovementVars();
        Move();
    }

    // Offload work to a single function instead of copy pasting same code twice.. EFFICIENCY!
    void OnTriggerEnter2D(Collider2D other) {
        GroundCheck(other);
    }

    void OnTriggerStay2D(Collider2D other) {
        GroundCheck(other);
    }

    void GroundCheck(Collider2D other) {
        // Although this approach is rather simple.
        // The only thing the player can abuse this
        // would be to break the finish, considering
        // that's the only trigger so far.
        // Update: Having the backdrop as a trigger
        // breaks this approach.. sadly.
        // The old approach simply turned it to true
        // when something got into it.

        if (other.gameObject.layer == wallLayer)
            touchingGround = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        // Although through jumping also turns this to false, in the event it turns to true
        // by some weird odds, this will fix it.

        if (other.gameObject.layer == wallLayer)
            touchingGround = false;
    }

    void Move() {
        Vector2 toMove = new Vector2();

        if (up) {
            if (touchingGround) {
                rb.AddForce(new Vector2(0,jumpPower),ForceMode2D.Impulse);
                touchingGround = false;
            }
        }

        if (left) {
            toMove.x = -(touchingGround ? groundMovementSpeed : airMovementSpeed) / movementDivider;
        } else if (right) {
            toMove.x = (touchingGround ? groundMovementSpeed : airMovementSpeed) / movementDivider;
        }

        tf.Translate(toMove);
    }

    void UpdateMovementVars() {
        left = right = up = down = false;

        left = id.leftArrow;
        right = id.rightArrow;
        up = id.upArrow;
        down = id.downArrow; // Haven't found a purpose for down key yet.. time will tell.

        if (left && right)
            left = right = false;
    }
}
