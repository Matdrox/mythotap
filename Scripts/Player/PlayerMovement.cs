using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameObject enemy;
	private Enemy enemyScript;
    private bool isMoving;
    private Vector3 originPos, targetPos;
    private float moveTime = 0.2f;

		void Start() {
				enemyScript = enemy.GetComponent<Enemy>();
		}

    void Update() {
		if (Input.anyKeyDown) {
			var randInt = Random.Range(1, 4);
			switch (randInt) {
				case 1:
					StartCoroutine(enemyScript.Move(Vector2.up));
					break;
				case 2:
					StartCoroutine(enemyScript.Move(Vector2.down));
					break;
				case 3:
					StartCoroutine(enemyScript.Move(Vector2.left));
					break;
				case 4:
					StartCoroutine(enemyScript.Move(Vector2.right));
					break;
				
			}
		}

        if (Input.GetKey(KeyCode.UpArrow) && !isMoving) {
            StartCoroutine(Move(Vector2.up));
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isMoving) {
            StartCoroutine(Move(Vector2.down));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving) {
            StartCoroutine(Move(Vector2.left));
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving) {
            StartCoroutine(Move(Vector2.right));
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
