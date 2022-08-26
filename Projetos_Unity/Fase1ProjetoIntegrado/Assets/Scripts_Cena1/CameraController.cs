using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    float initial_position;
    public bool MovimentarEsquerda = false;
    public bool MovimentarDireita = false;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initial_position = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarEsquerda = false;
        MovimentarDireita = false;
        if(transform.position.x > initial_position)
        {
            MoverEsquerda();
        }
        if(transform.position.x <= 12)
        {
            MoverDireita();
        }
    }
        
    void MoverEsquerda()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (Vector3.left * Time.deltaTime * speed);
            MovimentarEsquerda = true;
        }
    }
    void MoverDireita()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (Vector3.right * Time.deltaTime * speed);
            MovimentarDireita = true;
        }
    }
}
