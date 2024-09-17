using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody movementP;
    public float jumpForce;
    public int maxJumps;
    private int remainingJumps;
    public LayerMask floorLayer;
    private BoxCollider boxCollider;
    [SerializeField] private float velocity;
    [SerializeField] private Vector3 direction;

    private void Awake()
    {
        movementP = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }
    public void movementDirection(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    //
  //  bool onTheFloor()
  //  {
  //      RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, floorLayer);
  //      return raycastHit.collider != null;
  //  }
    public void Jumps(InputAction.CallbackContext context)
   {
      //     float inputJump = context.ReadValue<float>();
      //     if (onTheFloor())
      //     {
      //         remainingJumps = maxJumps;
      //     }
      //     if (context.performed && remainingJumps > 0)
      //     {
      //         remainingJumps = remainingJumps - 1;
            //
            movementP.velocity = new Vector3(movementP.velocity.x, 0f);
            movementP.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            //
      //     }
    }
    //
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(direction.x * velocity, movementP.velocity.y, direction.y * velocity);
        movementP.velocity = movement;
    }
}
