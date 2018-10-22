using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PogoStickUpperPart : MonoBehaviour {

    private void Update()
    {
        if (transform.position.y <= 0)
            StartCoroutine(ReloadScene());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.name == "Top")
             StartCoroutine(ReloadScene()); 
    } 

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
