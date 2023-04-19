using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject Enemigo;
    private bool isPlayerInRange;

    
    void Update()
    {
        if(isPlayerInRange){
            Enemigo.SetActive(true);
            Destroy(this.gameObject);
        }
    }
     
      private void OnCollisionEnter2D(Collision2D collision) {
         if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
}
