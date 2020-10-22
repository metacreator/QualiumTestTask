using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public Player Player;
    public CheckpointList CheckpointList;
    public LineRenderer LineRenderer;

    private bool CheckpointsSpawned;


    private void Awake()
    {
        LineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !CheckpointsSpawned)
        {
            SpawnCheckpoints();
        }

        if (CheckpointsSpawned)
        {
            Player.Move(ClosestCheckpoint().transform);
            DrawATrajectory();
        }
    }

    private void SpawnCheckpoints()
    {
        foreach (var checkpoint in CheckpointList.Checkpoints)
        {
            checkpoint.gameObject.SetActive(true);
        }

        CheckpointsSpawned = true;
    }

    private void DrawATrajectory()
    {
        LineRenderer.gameObject.SetActive(true);
        Vector3 startingPoint = ClosestCheckpoint().position;
        Vector3 endingPoint = Player.transform.position;
        LineRenderer.SetVertexCount(2);
        LineRenderer.SetPosition(0, startingPoint);
        LineRenderer.SetPosition(1, endingPoint);
    }

    private Transform ClosestCheckpoint()
    {
        Checkpoint cMin = null;
        var minDistance = Mathf.Infinity;
        var currentPosition = Player.transform.position;

        if (CheckpointList.Checkpoints.Count == 0)
            return Player.transform;

        foreach (var c in CheckpointList.Checkpoints)
        {
            float distance = Vector3.Distance(c.transform.position, currentPosition);
            if (distance < minDistance)
            {
                cMin = c;
                minDistance = distance;
            }
        }

        return cMin.transform;
    }
}