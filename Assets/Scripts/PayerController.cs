using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PayerController : MonoBehaviour
{
    
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    //private bool HasDied = false;
    public Animator animator;
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public CoinManager cm;
    public HealthManager hm;
    [SerializeField] private AudioSource audioSource;
    
    public GameObject FimishMenuUI;
    public GameObject OpenedDoor1;
    public GameObject LockedDoor1;

    public GameObject OpenedDoor2;
    public GameObject LockedDoor2;

    public GameObject OpenedChest;
    public GameObject LockedChest;
    public GameObject selectedNextLevelButton;


    // Update is called once per frame
    void Update()
    {
        Controls();
        

        if (cm.coinCount >= 5)
        {
            LockedDoor1.SetActive(false);
            OpenedDoor1.SetActive(true);

            LockedDoor2.SetActive(false);
            OpenedDoor2.SetActive(true);


        }
       

    }

    public void Controls()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //animator.SetBool("isJumping", true);
            animator.SetTrigger("jump");
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            //animator.SetBool("isJumping", false);
            

        }



        Flip();
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }






    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }

    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            cm.coinCount++;
            audioSource.Play();           
        }

        if (other.gameObject.CompareTag("Treasure"))
        {
            //other.gameObject.SetActive(false);
            cm.coinCount=5;
            audioSource.Play();
            LockedChest.SetActive(false);
            OpenedChest.SetActive(true);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(selectedNextLevelButton);
            FimishMenuUI.SetActive(true);
        }





    }
    



}
