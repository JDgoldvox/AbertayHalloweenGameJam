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
            
            SoundManager.instance.PlaySound(SoundManager.SFX.EXP_PICKUP, other.transform, 0.2f,false);
        }
    }

    private void XPTrigger(float amount)
    {
        XP.Instance.IncreaseXP(amount);
    }

}
