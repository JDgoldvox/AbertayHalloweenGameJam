using System.Runtime.CompilerServices;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Xp"))
        {
            //Get Enemy Xp drop
            float dropAmount = other.gameObject.GetComponent<xpDrop>().xpAmount;
            XPTrigger(dropAmount);  
            Destroy(other.gameObject);
        }
    }

    private void XPTrigger(float amount)
    {
        XP.Instance.IncreaseXP(amount);
    }

}
