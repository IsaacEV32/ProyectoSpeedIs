using UnityEngine;

public class Goal : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Vehicle>(out Vehicle player) && GameManager.instance.GetCheckPoints() >= GameManager.instance.GetTotalCheckPoints())
        {
            GameManager.instance.SumLap();
            GameManager.instance.ResetEveryCheckpoint();
        }
    }
}
