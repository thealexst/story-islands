using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    public enum PickupObject {COIN,GOLD_COIN};
    public PickupObject currentObject;
    public int pickupQuantity;

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            if(currentObject == PickupObject.COIN)
            {
                PlayerController.playerController.coins += pickupQuantity;
                Debug.Log(PlayerController.playerController.coins);
            }
            else if(currentObject == PickupObject.GOLD_COIN)
            {
                PlayerController.playerController.gold_coin += pickupQuantity;
                Debug.Log(PlayerController.playerController.gold_coin);
            }
            
         
        }
    }
}
