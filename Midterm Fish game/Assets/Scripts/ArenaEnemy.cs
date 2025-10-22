using UnityEngine;

public class ArenaEnemy : MonoBehaviour
{
    void OnDestroy()
    {
        ArenaBehavior.Instance._deadEnemies++;
    }
}
