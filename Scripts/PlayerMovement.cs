using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private bool isMoving;
    private Vector3 originPos, targetPos;
    private float moveTime = 0.2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving) {
            StartCoroutine(MovePlayer(Vector2.up));
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isMoving) {
            StartCoroutine(MovePlayer(Vector2.down));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving) {
            StartCoroutine(MovePlayer(Vector2.left));
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving) {
            StartCoroutine(MovePlayer(Vector2.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 dir) {
        isMoving = true;

        float elapsedTime = 0;

        originPos = transform.position;
        targetPos = originPos + dir;

        while(elapsedTime < moveTime) {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime/moveTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
