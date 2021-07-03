using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private LayerMask tileLayer;
    private float rayDistance = 0.7f;
    private Vector2 moveDirection = Vector2.down;   // ���� ������ �Ʒ��� ����
    //private Direction direction = Direction.Down;
    
    private Movement2D movement2D;

    private void Awake()
    {
        tileLayer = 1 << LayerMask.NameToLayer("Tile");
        movement2D = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // ���� Ű �Է����� �̵����� ����
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
            //direction = direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
            //direction = direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;
            //direction = direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right;
            //direction = direction.Right;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, rayDistance, tileLayer);
        if (hit.transform == null)
        {
            // Ű �Է� �� MoveTo �Լ��� �̵������� �Ű� ������ ����
            movement2D.MoveTo(moveDirection);
            /*
            bool movePossible = movement2D.MoveTo(moveDirection);
            if (movePossible)
            {
                transform.localEulerAngles = Vector3.forward * 90 * (int)direction;
            }
            */
        }
    }
}
