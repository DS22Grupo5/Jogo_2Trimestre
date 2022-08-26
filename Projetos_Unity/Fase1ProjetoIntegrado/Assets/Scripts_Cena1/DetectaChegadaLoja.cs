using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectaChegadaLoja : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public AudioSource Audio;
    public bool EntrarLoja = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        
        if(collisionInfo.gameObject.tag == "Player")
        {
            Audio.Play();
            EntrarLoja = true;
            SceneManager.LoadScene("Fase1_Parte3");
        }
    }
}
