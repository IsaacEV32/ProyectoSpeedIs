using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    bool havePassed = false;
    private void Awake()
    {
        GameManager.instance.CalculateTotalOfCheckPoints();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.AddCheckpoint(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Vehicle>(out Vehicle player) && !havePassed)
        {
            GameManager.instance.SumCheckpoint();
            havePassed = true;
        }
    }
    internal bool GetIfCheckpointHavePassed()
    {
        return havePassed;
    }
    internal void ResetCheckpointHavePassed()
    {
        havePassed = false;
    }
}
