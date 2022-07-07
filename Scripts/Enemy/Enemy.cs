using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool isMoving;
    public Vector3 originPos, targetPos;
    public float moveTime = 0.2f;

    void Update() {
        if (Input.anyKey && !isMoving) {
            var randInt = Random.Range(0, 4);
            switch (randInt) {
                case 0:
                    StartCoroutine(Move(Vector2.up));
                    break;
                case 1:
                    StartCoroutine(Move(Vector2.down));
                    break;
                case 2: case 3:
                    StartCoroutine(Move(Vector2.left));
                    break;
                case 4:
                    StartCoroutine(Move(Vector2.right));
                    break;
            }
        }
    }


    private IEnumerator Move(Vector3 dir) {
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
