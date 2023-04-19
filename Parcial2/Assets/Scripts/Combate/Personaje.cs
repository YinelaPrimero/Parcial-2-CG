using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    //public string nombre;
    public Habilidad[] listaHabilidades;
    public float vida, fuerza;
    //public string armadura;
    public float indexResistencia;
    public bool isDead;
    public BattleManager battleManager;
//    public Slider BarraDeVida;

    public List<Personaje> rivales;

    public Animator animator;

    private void Start()
    {
        isDead = false;
        battleManager = FindObjectOfType<BattleManager>();
    }

    public void LanzarHabilidad(int index)
    {
        listaHabilidades[index].Atacar();
    }

    public void TakeDamage(float cant)
    {
        int dado = Random.Range(0, 10);
        float vidaInicio = vida;

        if(indexResistencia > 0)
        {
            if (dado > 7 && dado <= 9)
            {
                vida -= cant;
            }

            else if (dado > 3 && dado < 7)
            {
                vida = vida - (cant - Random.Range(0, indexResistencia));

                if (vida > vidaInicio)
                {
                    vida = vidaInicio;
                }
            }

            else if (dado >= 0 && dado <= 3)
            {
                vida = vida - (cant - Random.Range(0, indexResistencia) - Random.Range(0, 4));

                if(vida > vidaInicio)
                {
                    vida = vidaInicio;
                }
                
            }

            Debug.Log($"Se amortiguaron {vida - vidaInicio + cant} pts");
        }

        else
        {
            vida -= cant;
        }

        Debug.Log($"La vida actual ahora es: {vida}");

        if(vida <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        if(this is Heroe)
        {
            CambiarAnimacion("death");
        }
        else if (this is Enemigo)
        {
          //  GetComponent<Enemigo>().SoltarDrop();
        }
        
        isDead = true;
    }

    public void CambiarAnimacion(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
