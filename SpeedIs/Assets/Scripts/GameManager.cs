using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text lapsText;
    int roundsCompleted = 1;
    int totalRounds = 3;
    public static GameManager instance;
    int checkpoints = 0;
    int checkpointsPassed = 0;
    List<Checkpoints> listOfCheckpoints = new List<Checkpoints>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lapsText.text = "Laps: " + roundsCompleted + " / " + totalRounds;
    }
    internal void AddCheckpoint(Checkpoints checkpoint)
    {
        listOfCheckpoints.Add(checkpoint);
    }
    internal void CalculateTotalOfCheckPoints()
    {
        checkpoints++;
    }
    internal void SumLap()
    {
        if (roundsCompleted < totalRounds)
        {
            roundsCompleted++;
            lapsText.text = "Laps: " + roundsCompleted + " / " + totalRounds;
        }
        else
        {
            lapsText.text = "Circuit Completed";
        }
    }
    internal void SumCheckpoint()
    {
        checkpointsPassed++;
    }
    internal void ResetEveryCheckpoint()
    {
        foreach (Checkpoints checkpoint in listOfCheckpoints)
        {
            checkpoint.ResetCheckpointHavePassed();
        }
        checkpointsPassed = 0;

    }
    public int GetTotalCheckPoints()
    {
        return checkpoints;
    }
    public int GetCheckPoints()
    {
        return checkpointsPassed;
    }
}
