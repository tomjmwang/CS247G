using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class ZeroGravityField : MonoBehaviour
{
    private BoxCollider2D _collider;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        Debug.Log("here");
        if(player != null)
        {
            player.no_gravity = true;
            //_collider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        Debug.Log("exit");
        if(player != null)
        {
            player.no_gravity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
