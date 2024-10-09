using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerController playerController;
    public bool doorOpen;
    public int count;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerController.money >= count)
        {
            doorOpen = true;
        }

        if (doorOpen == true)
        {
            Destroy(gameObject);
        }
    }
}
