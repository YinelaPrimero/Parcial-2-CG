using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPueblo : MonoBehaviour
{
    public GameObject Player;
    private Vector3 PlayerPos;
    public float Smooth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = new Vector3 (Player.transform.position.x,transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp( transform.position, PlayerPos,Smooth* Time.deltaTime );
    }
}
