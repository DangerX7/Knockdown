using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    Vector2 moveValue;
    public void Move(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>() * Time.deltaTime * speed;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject.Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    private void Update()
    {
        transform.Translate(moveValue);
    }
}
