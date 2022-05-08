using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    public Joystick joystick;

    private Rigidbody2D myRB;
    private Animator myAnim;
    [SerializeField]
    public float speed;
    
    private float attackTime = .25f;
    private float attackCounter= .25f;
    private bool isAttacking;
       // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        myRB.velocity = new Vector2(joystick.Horizontal, joystick.Vertical).normalized * speed * Time.deltaTime;

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);

        if (joystick.Horizontal == 1 || joystick.Horizontal == -1 || joystick.Vertical == 1 || joystick.Vertical == -1)
        {
            myAnim.SetFloat("lastMoveX", joystick.Horizontal);
            myAnim.SetFloat("lastMoveY", joystick.Vertical);
        }

        if (isAttacking)
        {
            myRB.velocity = Vector2.zero;
            attackTime -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }
}
