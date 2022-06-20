using System;
using UnityEngine;

public class DamagedEnemy : MonoBehaviour
{
    public event Action<Vector3> OnTakeDamage;

    public void TakeDamage(ContactPoint contactPoint) 
    {
        OnTakeDamage.WriteLog(LogState.HiteEnemy)?.Invoke(contactPoint.point);
        gameObject.SetActive(false);
    }
}
