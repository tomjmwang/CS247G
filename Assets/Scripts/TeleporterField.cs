using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class TeleporterField : MonoBehaviour
{
    private BoxCollider2D _collider;

    public Vector2 target;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("vortexed");
            player.teleport = true;
            player.teleport_location = target;
            //_collider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.teleport = false;
        }
    }
}
