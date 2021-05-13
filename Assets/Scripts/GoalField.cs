using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Platformer.Mechanics;

public class GoalField : MonoBehaviour
{
    public string target = "Main";
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            SceneManager.LoadScene(sceneName: target);
        }
    }
}
