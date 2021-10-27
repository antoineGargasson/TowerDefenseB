using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform enemyTransform { get; set; } = null;

    private void Start()
    {
        enemyTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        enemyTransform.position += Vector3.right * Time.deltaTime * 3;
    }
}
