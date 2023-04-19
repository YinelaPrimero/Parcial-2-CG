using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : Personaje
{
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Enemigo enemy in FindObjectsOfType<Enemigo>())
        {
            rivales.Add(enemy);
        
    }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
