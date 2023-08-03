using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    bool inRange = false;

// [changle data from the player] //
    Vector3 moveData = Vector3.zero;
    Vector3 rotationInput = Vector3.zero;
    public float moveSpeed = 0.05f;
    public float rotationSpeed = 0.2f;
    public Transform head;

    // Start is called before the first frame update
    void OnMove(InputValue value)
    {
        moveData = value.Get<Vector2>();
        Debug.Log("detecting");
    }

    void OnLook(InputValue value){
        rotationInput.y = value.Get<Vector2>().x; //for left right movement
        rotationInput.x = value.Get<Vector2>().y; //For up and down movement
        var val = value.Get<Vector2>();
        rotationInput.y = val.x;
        rotationInput.x = -val.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotationInput.y) * rotationSpeed);

        var rot = head.rotation.eulerAngles + new Vector3(rotationInput.x, 0) * rotationSpeed;

        while (rot.x > 180f){
            rot.x -= 360f;
        }

        while (rot.x < -180f){
            rot.x += 360f;
        }

        if (rot.x > 60f){
            rot.x = 60f;
        }

        if (rot.x < -60f){
            rot.x = -60f;
        }

        
        head.rotation = Quaternion.Euler(rot);

        Vector3 fowardDir = transform.forward;
        Vector3 rightDir = transform.right;

        var moveFoward = fowardDir * moveData.y;
        var moveRight = rightDir * moveData.x;

        GetComponent<Rigidbody>().MovePosition(transform.position + (moveFoward + moveRight) * moveSpeed);

    }

}
