using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 0.2f;  // ��ĭ �̵��� �ҿ�Ǵ� �ð�
    private bool isMove = false;

    // PlayerController.cs ������ Vector2 Ÿ���� moveDirection�� �����µ�??
    public bool MoveTo(Vector3 moveDirection)
    {
        if (isMove)
        {
            return false;
        }

        // ���� ��ġ�κ��� �̵��������� 1 ���� �̵��� ��ġ�� �Ű������� �ڷ�ƾ �Լ� ����
        // �ڷ�ƾ �Լ���??
        StartCoroutine(SmoothGridMovement(transform.position + moveDirection));

        return true;
    }

    private IEnumerator SmoothGridMovement(Vector2 endPosition)
    {
        Vector2 startPosition = transform.position;
        float percent = 0;
        
        // moveTime �� ������ �ð����� while() ����
        isMove = true;
        while (percent < moveTime)
        {
            percent += Time.deltaTime;
            // startPosition���� endPosition���� moveTime �ð����� �̵�
            transform.position = Vector2.Lerp(startPosition, endPosition, percent / moveTime);

            // yield ��?
            yield return null;
        }
        isMove = false;
    }
}
