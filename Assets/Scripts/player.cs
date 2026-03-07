using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class player : MonoBehaviour
{
    [Header("Basic Stats")]
    public float health = 5;
    public float attack;
    public float defense;
    public float speed = 5;

    [Header("Attack Stuff")]
    public float attackSpeed;
    public float IFrames;

    [Header("Movement Settings")]
    public Vector2 movementInput;
    public Rigidbody rb;

    [Header("GameObjects")]
    public Transform Enemy;
    public gameManager Manager;


    [Header("UI References")]
    public TextMeshProUGUI healthText; // 2. Create the reference

    private void OnMove(InputValue inputValue)
    {
        //grab values from unity input system (for both mediums) and set it to this variable
        movementInput = inputValue.Get<Vector2>();

        //Debug.Log(inputValue.Get<Vector2>()); to show a button was pressed and recieved for debugging purposes, can be removed later
    }
    private void FixedUpdate()
    {
        ManageMovement();
    }


    private void ManageMovement()
    {
        Vector3 moveDir = transform.right * movementInput.x + transform.forward * movementInput.y;

        // Apply velocity while preserving existing gravity (y-axis)
        rb.linearVelocity = new Vector3(moveDir.x * speed, rb.linearVelocity.y, moveDir.z * speed);
    }

    public void takeDamage()
    {
        // Health, enemy attack, and defense are taken into consideration
        // When hit, damage is subtracted by player defense, then that total is subtracted from the total health of the player

        health -= (attack - defense); 
        if (health <= 0) // prevents health from going below zero.
        {
            health = 0;
            Manager.gameOver();
        }

    }
   
    // Update is called once per frame
    void Update()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString("F0");
        }
    }
}
