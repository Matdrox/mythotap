using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public LayerMask wall;
    private bool isMoving;
    private Vector3 originPos, targetPos;
    private float moveTime = 0.2f;

    private void Update() {
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving) {
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, 1, 0), 0.2f, wall)) {
                StartCoroutine(Move(Vector2.up));
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isMoving) {
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(0, -1, 0), 0.2f, wall)) {
                StartCoroutine(Move(Vector2.down));
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving && transform.position.x > -8) {
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(-1, 0, 0), 0.2f, wall)) {
                StartCoroutine(Move(Vector2.left));
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving) {
            if (!Physics2D.OverlapCircle(transform.position + new Vector3(1, 0, 0), 0.2f, wall)) {
            StartCoroutine(Move(Vector2.right));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
        // Destroy(other.gameObject);
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
