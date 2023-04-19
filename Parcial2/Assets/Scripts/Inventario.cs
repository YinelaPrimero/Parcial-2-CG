using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
   public List<Text> textos = new List<Text>();
    public List<GameObject> item = new List<GameObject>();
    public GameObject inventario;
    public bool activar_inventario;
    Dictionary <string, int> itemInventario;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Pocion"))
        {
            item[0].SetActive(true);
            itemInventario["Pociones"]++;
            Destroy(collider.gameObject);
        }
        else if(collider.CompareTag("Dinero"))   
        {
        
            item[1].SetActive(true);
            itemInventario["Dinero"]+=100;
            Destroy(collider.gameObject);
        }
        else if(collider.CompareTag("Dinero3"))   
        {
        
            item[1].SetActive(true);
            itemInventario["Dinero"]+= 250;
            Destroy(collider.gameObject);
        }
        else if(collider.CompareTag("Dinero4"))   
        {
        
            item[1].SetActive(true);
            itemInventario["Dinero"]+= 350;
            Destroy(collider.gameObject);
        }

        else if(collider.CompareTag("Cofre"))   
        {
            item[2].SetActive(true);
            itemInventario["Cofres"]++;
            Destroy(collider.gameObject);
        } 

        else if(collider.CompareTag("Arma"))   
        {
            item[3].SetActive(true);
            itemInventario["Armas"]++;
            Destroy(collider.gameObject);
        }

        else if(collider.CompareTag("Escapulario"))   
        {
            itemInventario["Escapulario"]++;
            Destroy(collider.gameObject);
        }
     
    }
     void Start()
    {
        //Inicilizamos la variable item con unos dato base
        itemInventario = new Dictionary<string, int>()
        {
            {"Pociones", 0},
            {"Dinero", 0},
            {"Cofres", 0},
            {"Armas", 0},
            {"Escapulario", 0}
        };

    }

    void Update()
    {
        textos[0].text=itemInventario["Pociones"].ToString();
        textos[1].text=itemInventario["Dinero"].ToString();
        textos[2].text=itemInventario["Cofres"].ToString();
        textos[3].text=itemInventario["Armas"].ToString();
        
        if(activar_inventario)
        {
            inventario.SetActive(true);
        }
        else
        {
            inventario.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            activar_inventario =! activar_inventario;
        }
    }
}
