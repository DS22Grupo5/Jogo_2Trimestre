using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControrllerCena2 : MonoBehaviour
{
    public Rigidbody2D rig;
    public Animator animar_personagem;
    public SpriteRenderer spriteRenderer;
    public AudioSource Audio;
    public float speed;
    public float JumpForce;
    public float y_inicial;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animar_personagem = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        y_inicial = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        Jump();
        
    }
    void Move()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animar_personagem.SetBool("run", true);

        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animar_personagem.SetBool("run", true);   
        }
        else{
            animar_personagem.SetBool("run", false);   
        }

    }
    void Jump()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            animar_personagem.SetBool("jump", true);
            Audio.Play();
        }
    }
    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 9 || collisionInfo.gameObject.layer == 10)
        {
            animar_personagem.SetBool("jump", false);
        }
    }
}
