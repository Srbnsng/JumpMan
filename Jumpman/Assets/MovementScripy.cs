using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementScripy : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded = false;
    public Animator animator;
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent: UnityEvent<bool> { }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Jump();
       Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
       transform.position += movement * Time.deltaTime * movementSpeed;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetBool("IsJumping", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
     
        }
        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
