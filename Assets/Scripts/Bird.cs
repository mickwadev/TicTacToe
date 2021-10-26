using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Sprite DeadFlappy;
    public float FlappyForce;

    private bool isAlive = true;

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isAlive == true)
        {
            rigidbody2D.velocity = Vector2.up * FlappyForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Punkt") return;
        
        if (isAlive)
        {
            Debug.Log($"Hit Obstacle");
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = DeadFlappy;
            isAlive = false;
            rigidbody2D.velocity = Vector2.up * FlappyForce;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Punkt")
        {
            FindObjectOfType<GeneratorPrzeszkod>().DodajPunkt();
        }
    }
}
