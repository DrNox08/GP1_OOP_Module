using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5.0f;
    [SerializeField] LayerMask destroyableLayer;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, explosionRadius, destroyableLayer);
        foreach (var coll in colliders)
        {
            Destroy(coll.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}