using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour
{
   public string scene;
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            FindObjectOfType<SceneChanger>().TransitionToNewScene(scene);
            FindObjectOfType<Movement>().enabled = false;


        }
    }
}
