using UnityEngine;

public class PlayerFx : MonoBehaviour
{
    public enum AUDIO_CLIP { WALKING, RUNNING, JUMPING, CROUCHING, ATTACK_1, HIT, DEATH };

    private AudioSource audio_fx;
    public AudioClip player_walking;
    public AudioClip player_running;
    public AudioClip player_jumpjng;
    public AudioClip player_croiching;
    public AudioClip player_attack_1;
    public AudioClip player_hit;
    public AudioClip player_death;

    private void Awake()
    {
        audio_fx = GetComponent<AudioSource>();
    }

    public void PlayFX(AUDIO_CLIP action)
    {
        audio_fx.Pause();
        switch (action)
        {
            case AUDIO_CLIP.WALKING:
                audio_fx.clip = player_walking;
                break;
            case AUDIO_CLIP.RUNNING:
                audio_fx.clip = player_running;
                break;
            case AUDIO_CLIP.JUMPING:
                audio_fx.clip = player_jumpjng;
                break;
            case AUDIO_CLIP.CROUCHING:
                //audio_fx.clip = player_croiching;
                break;
            case AUDIO_CLIP.ATTACK_1:
                audio_fx.clip = player_attack_1;
                break;
            case AUDIO_CLIP.HIT:
                audio_fx.clip = player_hit;
                break;
            case AUDIO_CLIP.DEATH:
                //audio_fx.clip = player_death;
                break;
            default:
                break;
        }

        audio_fx.Play();
    }

    public void StopAudio()
    {
        audio_fx.Pause();
    }
}