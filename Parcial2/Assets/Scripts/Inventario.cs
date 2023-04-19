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
            if(item[0].GetComponent<Image>().enabled == false)
            {
                  item[0].GetComponent<Image>().enabled = true;
                  item[0].GetComponent<Image>().sprite = collider.GetComponent<SpriteRenderer>().sprite;
                   
            }
            itemInventario["Pociones"]++;
            Destroy(collider.GetComponent<GameObject>());
        }
        else if(collider.CompareTag("Dinero"))   
        {
            if(item[1].GetComponent<Image>().enabled == false)
            {
                  item[1].GetComponent<Image>().enabled = true;
                  item[1].GetComponent<Image>().sprite = collider.GetComponent<SpriteRenderer>().sprite;
                   
            }

            itemInventario["Dinero"]++;
            Destroy(collider.GetComponent<GameObject>());
        }

        else if(collider.CompareTag("Cofre"))   
        {
            if(item[2].GetComponent<Image>().enabled == false)
            {
                  item[2].GetComponent<Image>().enabled = true;
                  item[2].GetComponent<Image>().sprite = collider.GetComponent<SpriteRenderer>().sprite;
                   
            }

            itemInventario["Cofres"]++;
            Destroy(collider.GetComponent<GameObject>());
        } 

        

        else if(collider.CompareTag("Arma"))   
        {
            if(item[3].GetComponent<Image>().enabled == false)
            {
                  item[3].GetComponent<Image>().enabled = true;
                  item[3].GetComponent<Image>().sprite = collider.GetComponent<SpriteRenderer>().sprite;
                   
            }

            itemInventario["Armas"]++;
            Destroy(collider.GetComponent<GameObject>());
        }

        else if(collider.CompareTag("Escapulario"))   
        {
            itemInventario["Escapulario"]++;
            Destroy(collider.GetComponent<GameObject>());
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
        textos[0].text=" ";
        textos[1].text=" ";
        textos[2].text=" ";
        textos[3].text=" ";

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
