using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;
    private AudioSource audioSource;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.5f, 1.5f)]
    public float pitch;
    public void SetSource(AudioSource _source)
    {
        audioSource = _source;
        audioSource.clip = audioClip;
       
    }

    public void Play()
    {
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();

    }
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private Sound[] sounds;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("No Audio Manager In Scene");
        }
        else 
        {
            instance = this;
        }

    }
    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }

    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("Audiomanager : Sound not found");
    }

}
