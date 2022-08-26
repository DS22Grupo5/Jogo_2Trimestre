using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rig;
    public Animator animation_personagem;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        animation_personagem = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Move();
        Jump();
      
        
    }
    void Move()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (Vector3.left * 5 * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animation_personagem.SetBool("run", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (Vector3.right * 5 * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            animation_personagem.SetBool("run", true);
        }
        else{
            animation_personagem.SetBool("run", false);
        }
    }
    void Jump(){
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
