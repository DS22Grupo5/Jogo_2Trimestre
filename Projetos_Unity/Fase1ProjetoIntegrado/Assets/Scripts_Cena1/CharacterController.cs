using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5;
    public float JumpForce;
    private Rigidbody2D rig;
    public Sprite sprite_carro_explodido;
    public AudioSource Audio_ExplodirCarro;
    public AudioSource Audio_Jump;
    public Animator anim;
    public Animator animar_personagem;
    public bool caixa_aberta = false;
    public bool fruta_existe = true;
    public bool carro_explodido = false;

    public float y_inicial;
    SpriteRenderer spriteRenderer;
    SpriteRenderer sprite_carro;
    Transform position_fruit;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); 
        anim = GameObject.Find("Explosao").GetComponent<Animator>();
        animar_personagem = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();  
        sprite_carro = GameObject.Find("Carro").GetComponent<SpriteRenderer>();

        position_fruit = GameObject.Find("Lata").GetComponent<Transform>();

        Audio_ExplodirCarro = GetComponent<AudioSource>();
        
        y_inicial = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.y <= y_inicial + 0.5){
            Jump();
        }
        
        if(carro_explodido == true){
            StartCoroutine(Timer(1.0f));
        }
        
    }
    void Move(){
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animar_personagem.SetBool("run", true);
            transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animar_personagem.SetBool("run", true);
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            animar_personagem.SetBool("run", false);
        }
        
    }
    void Jump(){
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            animar_personagem.SetBool("jump", true);
            Audio_Jump.Play();
        }
        
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Respawn" && carro_explodido == false)
        {
            Audio_ExplodirCarro.Play();
        
            carro_explodido = true;
            anim.SetBool("explodir", true);
            Destroy(GameObject.Find("DetectaColisao"));
            
            sprite_carro.sprite = sprite_carro_explodido;
    
        }
        if(collisionInfo.gameObject.layer == 9 || collisionInfo.gameObject.layer == 7 || collisionInfo.gameObject.layer == 12)
        {
            animar_personagem.SetBool("jump", false);
        }
        if(collisionInfo.gameObject.layer == 6)
        {
            speed = 8;
        }
        if(fruta_existe == true)
        {
            if(collisionInfo.gameObject.layer == 8 && position_fruit.position.x >= 3)
            {
                fruta_existe = false;
                Destroy(GameObject.Find("Lata"));
            }
        }
        
    }
    private IEnumerator Timer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("explodir", false);

    }

    
}

