using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarNitaner : MonoBehaviour
{
    public bool direita = true;
    public bool esquerda = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direita == true){
            MoverDireita();
        }
        if(esquerda == true){
            MoverEsquerda();
        }
    }
    void MoverDireita()
    {
        transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if(transform.position.x >= 4){
            direita = false;
            esquerda = true;
        }
    }
    void MoverEsquerda()
    {
        transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 180, 0);

        if(transform.position.x <= 2.5){
            direita = true;
            esquerda = false;
        }
    }
}
