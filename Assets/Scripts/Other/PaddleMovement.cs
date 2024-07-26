using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField]
    private float paddleSpeed;

    Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("PlayerMovement");
    }

    // Update is called once per frame
    void Update()
    {
        float direction = moveAction.ReadValue<float>();

        if(Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            if (!IsPointerOverUIObject(touchPosition))
            {
                direction = TouchDirection(touchPosition);
            }
            
        }


        Vector3 newPosition = transform.position + new Vector3(direction, 0, 0) * paddleSpeed * Time.deltaTime;
        float ClampX = Mathf.Clamp(newPosition.x, -8.48f, 8.48f);
        newPosition = new Vector3(ClampX, newPosition.y, newPosition.z);
        transform.position = newPosition;



    }

    private float TouchDirection(Vector2 touchPosition)
    {
        if(touchPosition.x < Screen.width/2)
        {
            return -1f;
        }else
        {
            return 1f;
        }

    }

    private bool IsPointerOverUIObject(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = touchPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Boundaries"))
        {
           rb2d.velocity = Vector2.zero;
        }
        
    }
}
