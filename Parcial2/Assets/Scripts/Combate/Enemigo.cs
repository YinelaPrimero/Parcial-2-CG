using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;

public class Enemigo : Personaje
{
   // public GameObject jugador;
    public Heroe Heroe1;
    public Heroe Heroe2;
    public Heroe Heroe3;
    public Heroe Heroe4;
    public GameObject recompensa;
    [SerializeField] private bool sueltaEscapulario;


    // Start is called before the first frame update
    void Awake()
    {
        
            rivales.Add(Heroe1);
            rivales.Add(Heroe2);
            rivales.Add(Heroe3);
            rivales.Add(Heroe4);    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
       // if (collision.collider.CompareTag("Player"))
       // {
            //AlmacenarEnemigo.AlmacenarEsteEnemigo(gameObject);
        //    SceneManager.LoadScene("Combate");
        //    Destroy(gameObject);
        //}
    //}

   public void ActivarRecompensa()
    {
      recomoensa.SetActive(true); 
      
    }
}
