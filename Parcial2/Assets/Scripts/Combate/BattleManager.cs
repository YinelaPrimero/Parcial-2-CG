using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //Se deben a�adir los heroes, el enemigo
    //public GameObject enemySlot;
    public Heroe Heroe1;
    public Heroe Heroe2;
    public Heroe Heroe3;
    public Heroe Heroe4;
    public List<Heroe> listaHeroesEnBatalla = new List<Heroe>();
    public List<Enemigo> listaEnemigosEnBatalla = new List<Enemigo>();
    [SerializeField] private GameObject atck1, atck2, atck3, panel;
    public int turno = 0;
    public bool isWinner;

    // Start is called before the first frame update
    void Start()
    {
        isWinner = false;
        IniciarBatalla();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckHeroesConVida() && CheckEnemigosConVida())
        {
            if (turno < listaHeroesEnBatalla.Count)
            {
                TurnoDeAtaque(listaHeroesEnBatalla[turno]);
            }
            else if (turno >= listaHeroesEnBatalla.Count && turno < (listaEnemigosEnBatalla.Count + listaHeroesEnBatalla.Count))
            {
                TurnoDeAtaque(listaEnemigosEnBatalla[turno - listaHeroesEnBatalla.Count]);
            }
            else if (turno >= listaEnemigosEnBatalla.Count)
            {
                turno = 0;
            }
        }
        else if(CheckHeroesConVida() && !CheckEnemigosConVida())
        {
            Debug.Log("Ganador");
            isWinner = true;
            atck1.SetActive(false);
            atck2.SetActive(false);
            atck3.SetActive(false);

            //pantallaGanador.SetActive(true);
        }

        else if(!CheckHeroesConVida() && CheckEnemigosConVida())
        {
            Debug.Log("Perdedor");
            isWinner = false;
            atck1.SetActive(false);
            atck2.SetActive(false);
            atck3.SetActive(false);

            //pantallaPerdedor.SetActive(true);
        }
    }


    public void TurnoDeAtaque(Personaje player)
    {
        if(player != null)
        {
            panel.SetActive(true);
            if (player.GetType() == typeof(Heroe))
            {
                if (player.isDead == false)
                {
                    if (player.listaHabilidades.Length == 1)
                    {
                        atck1.SetActive(true);
                        foreach (Boton boton in atck1.GetComponentsInChildren<Boton>())
                        {
                            boton.personaje = player;
                        }

                        atck2.SetActive(false);
                        atck3.SetActive(false);
                        
                    }

                    else if (player.listaHabilidades.Length == 2)
                    {
                        atck1.SetActive(false);
                        atck2.SetActive(true);
                        foreach (Boton boton in atck2.GetComponentsInChildren<Boton>())
                        {
                            boton.personaje = player;
                        }
                        atck3.SetActive(false);
                    }

                    else if (player.listaHabilidades.Length == 3)
                    {
                        atck1.SetActive(false);
                        atck2.SetActive(false);
                        atck3.SetActive(true);
                        foreach (Boton boton in atck3.GetComponentsInChildren<Boton>())
                        {
                            boton.personaje = player;
                        }
                        atck3.GetComponentInChildren<Boton>().personaje = player;
                    }
                }
                else
                {
                    listaHeroesEnBatalla.Remove(listaHeroesEnBatalla[turno]);
                    turno++;
                }
            }
            else if (player.GetType() == typeof(Enemigo))
            {
                if (!player.isDead)
                {
                    player.LanzarHabilidad(0);
                }
                else
                {
                    listaEnemigosEnBatalla.Remove(listaEnemigosEnBatalla[turno]);
                    turno++;
                }
            }
        }
        else
        {
            turno++;
        }
    }

    public void IniciarBatalla()
    {
        
        turno = 0;

        listaHeroesEnBatalla.Add(Heroe1);
        listaHeroesEnBatalla.Add(Heroe2);
        listaHeroesEnBatalla.Add(Heroe3);
        listaHeroesEnBatalla.Add(Heroe4);


        foreach (Enemigo enemy in FindObjectsOfType<Enemigo>())
        {
            listaEnemigosEnBatalla.Add(enemy);
        }
    }

    public bool CheckHeroesConVida()
    {
        int cant = 0;
        foreach(Personaje p in listaHeroesEnBatalla)
        {
            if(listaHeroesEnBatalla.Count > 0)
            {
                if (p.vida >= 0)
                {
                    cant++;
                }
            }
        }

        if (cant == listaHeroesEnBatalla.Count)
        {
            
            return true;
        }
        
        return false;
    }

    public bool CheckEnemigosConVida()
    {
        int cant = 0;
        foreach (Personaje p in listaEnemigosEnBatalla)
        {
            if(listaEnemigosEnBatalla.Count > 0)
            {
                if (p.vida >= 0)
                {
                    cant++;
                }
            }
        }

        if (cant == listaEnemigosEnBatalla.Count)
        {
            
            return true;
        }
        
        return false;
    }

    public void TerminarBatalla() { 

    }
}
