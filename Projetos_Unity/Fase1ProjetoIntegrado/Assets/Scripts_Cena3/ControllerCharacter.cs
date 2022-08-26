using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacter : MonoBehaviour
{
    private Rigidbody2D rig;
    public Animator animation_personagem;
    public AudioSource Audio;
    public BoxCollider2D box_personagem;
    public SpriteRenderer spriteRenderer;
    public float JumpForce;
    public float speed;
    public float y_inicial;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); 
        animation_personagem = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        y_inicial = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.y <= y_inicial + 0.5)
        {
            Jump();
        }
    }
    void Move(){
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animation_personagem.SetBool("run", true);
            transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animation_personagem.SetBool("run", true);
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            animation_personagem.SetBool("run", false);
        }
    }
    void Jump(){
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            animation_personagem.SetBool("jump", true);
            animation_personagem.SetBool("run", false);
            Audio.Play();
        }
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 9 || collisionInfo.gameObject.layer == 7 || collisionInfo.gameObject.layer == 12)
        {
            animation_personagem.SetBool("jump", false);
        }
        if(collisionInfo.gameObject.layer == 13)
        {
            box_personagem.isTrigger = true;
        }
    }
}
