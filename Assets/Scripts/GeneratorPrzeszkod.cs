using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorPrzeszkod : MonoBehaviour
{
    public GameObject Przeszkoda;
    public float czas = 2f;
    public Text punktyTekst;
    public int punkty = 0;
    void Start()
    {
        InvokeRepeating("GenerujPrzeszkode", 4, czas);
    }


    public void GenerujPrzeszkode()
    {
        Instantiate(Przeszkoda, transform.position, quaternion.identity);
    }

    public void DodajPunkt()
    {
        punkty++;
        punktyTekst.text = punkty.ToString();
    }
    
}
