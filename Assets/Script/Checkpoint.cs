using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointList CheckpointList;
    public float Radius;
    private CircleCollider2D collider;

    private void Awake()
    {
        CheckpointList = GetComponentInParent<CheckpointList>();
        collider = GetComponent<CircleCollider2D>();
        Radius = collider.radius;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckpointList.Checkpoints.Remove(this);
        Destroy(gameObject);
    }
}