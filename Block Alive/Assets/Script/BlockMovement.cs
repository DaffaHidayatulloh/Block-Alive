using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public float moveDistance = 1.0f;
    public float moveSpeed = 5.0f;
    private bool canMove = true;

    void Update()
    {
        if (canMove)
        {
         
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveBlock(Vector3.right * moveDistance);
            }
      
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveBlock(Vector3.left * moveDistance);
            }
        }
    }

   
    void MoveBlock(Vector3 direction)
    {
        canMove = false;
        StartCoroutine(MoveCoroutine(direction));
    }

    
    IEnumerator MoveCoroutine(Vector3 direction)
    {
        float remainingDistance = moveDistance;
        while (remainingDistance > 0)
        {
            float moveStep = moveSpeed * Time.deltaTime;
            transform.position += direction * moveStep;
            remainingDistance -= moveStep;
            yield return null;
        }
        canMove = true;
    }
}

