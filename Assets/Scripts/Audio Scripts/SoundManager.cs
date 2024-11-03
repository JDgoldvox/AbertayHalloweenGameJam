using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource soundObject;
    [SerializeField] private SFXClips[] audioClips;
    public float pitchModifier = 1;
    [SerializeField] private float maxDistance = 100;

    [System.Serializable]
    public class SFXClips
    {
        public SFX SoundName;
        public AudioClip Clip;
    }

    public enum SFX
    {
        WEAPON_SHOOT,
        
        PLAYER_HIT_1,
        PLAYER_HIT_2,
        PLAYER_HIT_3,
        
        PLAYER_FOOTSTEPS_1,
        PLAYER_FOOTSTEPS_2,
        PLAYER_FOOTSTEPS_3,
        
        ENEMY_HIT,
        ENEMY_DIE,
        ZOMBIE_GROWL,
        PLAGUE_DOCTOR_NOISE,
        GHOST_SOUND,
        
        EXP_PICKUP,
        LEVEL_UP,
        
        HEARTBEAT_SLOW,
        HEARTBEAT_MID,
        HEARTBEAT_FAST,
        
        AMBIENT_SOUND_1,
        AMBIENT_SOUND_2,
        AMBIENT_SOUND_3,
        AMBIENT_SOUND_4,
        AMBIENT_SOUND_5,
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayAudioClip(AudioClip clip, Transform transform, float volume)
    {
        // Spawn Object
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        // Assign Audio Clip
        audioSource.clip = clip;

        // Change Volume
        audioSource.volume = volume;

        // Change Pitch
        audioSource.pitch = pitchModifier;

        // Play Audio
        audioSource.Play();

        // destroy object on clip end
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlaySound(SFX audioClip, Transform transform, float volume, bool useDistanceDropoff = false)
    {
        // Spawn Object
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        // Assign Audio Clip
        audioSource.clip = GetAudioClip(audioClip);

        // Change Volume
        audioSource.volume = useDistanceDropoff ? ApplyDistanceToVolume(volume, transform) : volume;

        // Change Pitch
        audioSource.pitch = pitchModifier;

        // Play Audio
        audioSource.Play();

        // destroy object on clip end
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSound(SFX[] audioClip, Transform transform, float volume)
    {
        // Get random clip
        int rand = Random.Range(0, audioClip.Length);

        // Spawn Object
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        // Assign Audio Clip
        audioSource.clip = GetAudioClip(audioClip[rand]);

        // Change Volume
        audioSource.volume = volume;

        // Play Audio
        audioSource.Play();

        // Destroy object on clip end
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    private AudioClip GetAudioClip(SFX sound)
    {
        foreach(SFXClips clip in audioClips)
        {
            if(clip.SoundName == sound)
            {
                return clip.Clip;
            }
        }
        return null;
    }

    private float ApplyDistanceToVolume(float volume, Transform audioSourceTransform)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            return volume;
        }
        Transform playerTransform = Player.transform;
        float newVolume = 0;
        float distance = Vector3.Distance(audioSourceTransform.position, playerTransform.position);
        float multiplier = Mathf.Clamp01(Mathf.Pow(1 - (distance / maxDistance), 2));
        newVolume = volume * multiplier;

        return newVolume;
    }
}

