
using UnityEngine;
using UnityEngine.PlayerLoop;

public class OverlapComponent : MonoBehaviour
{
    [Header("Overlap Settings")] [SerializeField]
    private float overlapRadius = 5.0f;

    [SerializeField] private Transform overlapOrigin;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Movement Settings")] [SerializeField]
    private float movementSpeed = 10.0f;

    [SerializeField] private float jumpForce = 5.0f;
    Rigidbody rb;
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * movementSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }
    
    bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(overlapOrigin.position, overlapRadius, groundLayerMask);
        return colliders.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(overlapOrigin.position, overlapRadius);
    }
}