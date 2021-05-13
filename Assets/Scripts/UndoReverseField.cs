using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class UndoReverseField : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!player.vortex)
            {
                player.input_reverse = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!player.vortex)
            {
                player.input_reverse = false;
            }
        }
    }
}
