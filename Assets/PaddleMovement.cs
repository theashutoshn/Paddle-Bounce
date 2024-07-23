using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField]
    private float paddleSpeed;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("PlayerMovement");
    }

    // Update is called once per frame
    void Update()
    {
        float direction = moveAction.ReadValue<float>();
        transform.position += new Vector3(direction, 0, 0) * paddleSpeed * Time.deltaTime;
    }
}
