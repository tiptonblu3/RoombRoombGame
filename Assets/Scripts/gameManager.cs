using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        Player.gameObject.SetActive(false);
    }


    public void CreateEnemy()
    {
        //Instantiate(Enemy, New Vector3(0, 1, 0);
    }
}
