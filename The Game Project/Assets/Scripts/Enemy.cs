using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 0.005f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
