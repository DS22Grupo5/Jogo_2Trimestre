using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerCena2 : MonoBehaviour
{
    public float speed;
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
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(transform.position.x > 1.3656)
            {
                transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if(transform.position.x < 12.40297)
            {
                transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);   
            }
        }
    }
}
