using UnityEngine;

public class ColliderIgnore : MonoBehaviour
{
    private void Start()
    {
        // Get the colliders
        CapsuleCollider capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        BoxCollider boxCollider = GetComponentInChildren<BoxCollider>();

        // Ignore collisions between the capsule and the box colliders
        Physics.IgnoreCollision(capsuleCollider, boxCollider);
    }
}
