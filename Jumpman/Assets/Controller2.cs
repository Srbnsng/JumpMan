using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller2 : MonoBehaviour
{
    public const float DEFAULT_VELOCITY = 30f;
    public const float BOOST_VELOCITY = 40f;
    public float jumpVelocity = 10f;
    public float movementSpeed = 40f;
    private new Rigidbody2D rigidbody2D;
    private enum State { jump, fall }
    private State state;
    private BoxCollider2D boxCollider2D;
    private Animator anim;
    public Text winnerText;
    public Button menuButton;

    [SerializeField] private LayerMask platformLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        VelocityState();
        anim.SetInteger("state", (int)state);
        HandleMovement();
        //CheckScreen();
    }

    void Jump()
    {
        //Input.GetKeyDown(KeyCode.Space)
        if (IsGrounded() && rigidbody2D.velocity.y <= 0f)
        {
            state = State.jump;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;

        }
    }


    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 1f, platformLayerMask);
        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.tag == "Broken")
        {
            Debug.Log("Collided!");
            var BrokenPlatform = raycastHit2D.collider.GetComponent<BrokenPlatform>();
            if (rigidbody2D.velocity.y <= 0f)
                BrokenPlatform.StartAnim();
        }
        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.tag == "Boost")
        {
            jumpVelocity = BOOST_VELOCITY;
        }
        else
        {
            jumpVelocity = DEFAULT_VELOCITY;
        }


        return raycastHit2D.collider != null;
    }


    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-movementSpeed, rigidbody2D.velocity.y);
            transform.localScale = new Vector2(-6, 6);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidbody2D.velocity = new Vector2(+movementSpeed, rigidbody2D.velocity.y);
                transform.localScale = new Vector2(6, 6);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
        }
    }

    private void VelocityState()
    {
        if (state == State.jump)
        {
            if (rigidbody2D.velocity.y < .1f)
            {
                state = State.fall;
            }
        }
    }

    void CheckScreen()
    {
        if (transform.position.x <= -Screen.width / 2)
        {
            Debug.Log("Left");
        }
        if (transform.position.x >= Screen.width / 2)
        {
            Debug.Log("Right");
        }
    }

    private void OnBecameInvisible()
    {
        if (transform.position.x < 0)
        {
            transform.position = new Vector3((-transform.position.x) - 2f, transform.position.y, transform.position.z);
            Debug.Log("Left");

        }
        else if (transform.position.x > 0)
        {
            transform.position = new Vector3((-transform.position.x) + 2f, transform.position.y, transform.position.z);

            Debug.Log("Right");
        }
        if(transform.position.x >= -38 && transform.position.x <= 38)
        {
            winnerText.text = "Vulpoiu' wins! ";
            winnerText.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
