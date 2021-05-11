using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class GravityField : MonoBehaviour
{
    private BoxCollider2D _collider;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.no_gravity = false;
            //_collider.enabled = false;
        }
    }
}
