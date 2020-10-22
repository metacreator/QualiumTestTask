using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Transform target)
    {
        LookAt(target);
        Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        rigidbody2D.MovePosition(newPosition);
    }

    private void LookAt(Transform target)
    {
        Vector3 playerPosition = Camera.main.ScreenToWorldPoint(transform.position);
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(target.position);

        Vector2 dir = new Vector2(targetPosition.x - playerPosition.x, targetPosition.y - playerPosition.y);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.up = dir;
    }
}