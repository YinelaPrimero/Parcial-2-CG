using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Personaje personaje;
    public int index;
    private string trigger = "atack";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RealizarAtaque()
    {
        
        personaje.CambiarAnimacion(trigger+(index+1));
        
    }

   
}
