using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MoverVidas : MonoBehaviour
{
    public float speed;
    public GameObject objCamera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    void Move()
    {
        if(GameObject.Find("Main Camera").GetComponent<CameraController>().MovimentarEsquerda == true)
        
        {
            transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);

        }
        if(GameObject.Find("Main Camera").GetComponent<CameraController>().MovimentarDireita == true)
        {
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
        }
    }
}
