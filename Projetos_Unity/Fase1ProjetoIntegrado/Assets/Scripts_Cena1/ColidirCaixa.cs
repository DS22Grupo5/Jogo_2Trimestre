using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColidirCaixa : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    public bool personagem_colidiu = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(personagem_colidiu == true && transform.position.x <= 3.4)
        {
            JogarLata();
        }    
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            personagem_colidiu = true;
        }
    }
    void JogarLata()
    {
        transform.position = transform.position + (Vector3.right * 3 * Time.deltaTime);        

    }
}
