using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectaChegadaLojaCena3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Fase1_Parte3");
        }
    }
}