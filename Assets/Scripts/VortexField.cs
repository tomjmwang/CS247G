using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class VortexField : MonoBehaviour
{
    private BoxCollider2D _collider;

    public Vector2 center;
    public float x_coefficient = 1.0f;
    public float y_coefficient = 1.0f;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            Debug.Log("vortexed");
            if (!player.vortex) {
                player.vortex = true;
                player.vortex_x_coefficient = x_coefficient;
                player.vortex_y_coefficient = y_coefficient;
            }
            
            player.vortex_center = center;
            //_collider.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.vortex = true;
            player.vortex_x_coefficient = x_coefficient;
            player.vortex_y_coefficient = y_coefficient;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            if (player.vortex)
            {
                player.vortex = false;
            }
            
        }
    }
}
