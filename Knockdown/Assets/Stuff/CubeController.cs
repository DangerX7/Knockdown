using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movementInput.x + " 0 " + movementInput.y);
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
    }

    public void OnrMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
