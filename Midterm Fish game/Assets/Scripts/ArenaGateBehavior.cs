using UnityEngine;

public class ArenaGateBehavior : MonoBehaviour
{
    void Update()
    {
        if (ArenaBehavior.Instance._wave3Over == true)
        {
            Destroy(gameObject);
        }
    }
}
