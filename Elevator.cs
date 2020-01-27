using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //Script para que se muevan las plataformas ya sea en horizontal o en vertical

    public Transform target; //Zona hasta la que se mueve

    public float speed;

    private Vector3 start, end;


    void Start()
    {

        if (target != null)
        {
            target.parent = null;
            start = transform.position;  //Creamos una zona de principio y fin
            end = target.position;
        }

    }


    void FixedUpdate()
    {
        //Hacemos que si llega al end se flipee y haga el camino contrario. Así en bucle

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (transform.position == target.position)
        {
            target.position = start;
        }
    }
}

