using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer < 0)
        {
            int randomInt = UnityEngine.Random.Range(1, 4);

            switch (randomInt)
            {
                case 1:
                    SoundManager.instance.PlaySound(SoundManager.SFX.AMBIENT_SOUND_1, transform, 0.5f, false);
                    timer = 20;
                    break;
                case 2:
                    SoundManager.instance.PlaySound(SoundManager.SFX.AMBIENT_SOUND_2, transform, 0.5f, false);
                    timer = 20;
                    break;
                case 3:
                    SoundManager.instance.PlaySound(SoundManager.SFX.AMBIENT_SOUND_3, transform, 0.5f, false);
                    timer = 20;
                    break;
                case 4:
                    SoundManager.instance.PlaySound(SoundManager.SFX.AMBIENT_SOUND_5, transform, 0.5f, false);
                    timer = 50;
                    break;
            }
        }
    }
}
