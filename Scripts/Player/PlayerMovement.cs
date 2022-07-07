using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private GameObject[] enemies;
	private List<Enemy> enemyScripts = new List<Enemy>();
    private bool isMoving;
    private Vector3 originPos, targetPos;
    private float moveTime = 0.2f;

		void Start() {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies) {
                enemyScripts.Add(enemy.GetComponent<Enemy>());
            }
		}

    void Update() {
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
