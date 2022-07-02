using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum DIRECTION_TYPE {
        STOP,
        RIGHT,
        LEFT,
    }

    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    public float speed;

    public float jumpPower;

    // GameObject playerPink = GameObject.Find("PlayerPink");
    // GameObject playerBlue = GameObject.Find("PlayerBlue");

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // Physics.gravity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x == 0) {
            direction = DIRECTION_TYPE.STOP;
        } else if (x > 0) {
            direction = DIRECTION_TYPE.RIGHT;
        } else if (x < 0) {
            direction = DIRECTION_TYPE.LEFT;
        }

        if (Input.GetKeyDown("space")) {
            Jump();
        } else {
            animator.SetBool("isJumping", false);
        }
    }

    public void FixedUpdate() {
        float xSpeed = 0.0f;
        if (direction == DIRECTION_TYPE.STOP) {
            xSpeed = 0.0f;
        } else if (direction == DIRECTION_TYPE.RIGHT) {
            transform.localScale = new Vector3(1, 1 , 1);
            xSpeed = speed;
        } else if (direction == DIRECTION_TYPE.LEFT) {
            transform.localScale = new Vector3(-1, 1, 1);
            xSpeed = -speed;
        }
        GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, GetComponent<Rigidbody>().velocity.y, 0);
    }

    public void Jump() {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        animator.SetBool("isJumping", true);
    }
}