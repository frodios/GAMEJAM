using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControll : MonoBehaviour
{


    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private Animator animator;
    [SerializeField] private SoundControl SC;


    Vector3 InitLoc;

    private Vector2 targetVelocity;

    public float runSpeed = .2f;
    private Vector2 m_Velocity = Vector2.zero;
    private float m_MovementSmoothing = 0.7f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    float mouseX = 0f;
    float mouseY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InitLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        verticalMove = Input.GetAxisRaw("Vertical");

        mouseX = Input.GetAxisRaw("Mouse X");

        mouseY = Input.GetAxisRaw("Mouse Y");

        if (verticalMove > 0) animator.SetInteger("Dir", 0);
        if (verticalMove < 0) animator.SetInteger("Dir", 2);
        if (horizontalMove > 0) animator.SetInteger("Dir", 1);
        if (horizontalMove < 0) animator.SetInteger("Dir", 3);

        targetVelocity = new Vector2(horizontalMove * runSpeed, verticalMove * runSpeed);

        
        

        //Debug.Log(horizontalMove + " " + verticalMove);

        if (Input.GetButtonDown("Jump"))
        {
            SC.TogglePlay();
        }
    }

    void FixedUpdate()
    {
        m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    void Die()
    {
        transform.position = InitLoc;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Lv1Border"))
        {
            Die();
            Debug.Log("WHYYYYYYY!!!!!");
        }
    }

}
