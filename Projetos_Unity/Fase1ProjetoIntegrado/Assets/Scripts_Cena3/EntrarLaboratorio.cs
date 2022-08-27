using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarLaboratorio : MonoBehaviour
{
    public Sprite new_sprite;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = new_sprite;

        }
    }
}
