using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject fixedRocket;
    public GameObject brokenRocket;
    public Collider2D col;
    // Parts displayed above, 0=eng, 1=nose, 2=lwng, 3=rwng
    public SpriteRenderer[] parts = new SpriteRenderer[4];


    // Start is called before the first frame update
    void Start()
    {
        fixedRocket.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool[] playersParts = collision.gameObject.GetComponent<Player>().parts;
            if (playersParts[0] && playersParts[1] && playersParts[2]) completedRocket();
            if (playersParts[0]) collectedPart("engine");
            if (playersParts[1]) collectedPart("nose");
            if (playersParts[2]) collectedPart("wing");

        }
    }

    private void completedRocket()
    {
        fixedRocket.SetActive(true);
        brokenRocket.SetActive(false);
        col.enabled = false;
    }

    private void collectedPart(string part)
    {
        switch (part)
        {
            case "engine":
                parts[0].color = Color.white;
                break;

            case "nose":
                parts[1].color = Color.white;
                break;

            case "wing":
                parts[2].color = Color.white;
                parts[3].color = Color.white;
                break;
        }
    }
}