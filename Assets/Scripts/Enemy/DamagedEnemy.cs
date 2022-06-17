using UnityEngine;

public class DamagedEnemy : MonoBehaviour
{
    public void TakeDamage() 
    {
        gameObject.SetActive(false);
    }
}
