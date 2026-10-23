using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerBehavior player)) return;

        player.CollectCoin();
        Destroy(this.gameObject);
    }
}
