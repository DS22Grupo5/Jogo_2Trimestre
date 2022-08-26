using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerCena3 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -32.7)
        {
            transform.position = transform.position + (Vector3.left * 3 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < -20.5)
        {
            transform.position = transform.position + (Vector3.right * 3 * Time.deltaTime);
        }
    }
}
