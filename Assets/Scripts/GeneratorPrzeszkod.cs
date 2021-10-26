using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GeneratorPrzeszkod : MonoBehaviour
{
    public GameObject Przeszkoda;
    public float czas = 2f;
    void Start()
    {
        InvokeRepeating("GenerujPrzeszkode", 4, czas);
    }


    public void GenerujPrzeszkode()
    {
        Instantiate(Przeszkoda, transform.position, quaternion.identity);
    }
    
}
