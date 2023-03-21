using UnityEngine;
/*
 * This class functions to play the related clip of the calling class. It sets the volume
 * and pitch specific to the appropriate audio clip.
 */
public class AudioManager : MonoBehaviour
{
    //unity attribute header for inspector
    [Header("Audio Sources")]
    // Inspector available references
    public AudioSource fruitSource;
    public AudioClip cherrySound;
    public AudioClip bananaSound;
    public AudioClip watermelonSound;
    public AudioSource bombSource;
    public AudioClip bombSound;

    // References for static use of class function play
    public static AudioSource _fruitSource;
    public static AudioClip _cherrySound;
    public static AudioClip _bananaSound;
    public static AudioClip _watermelonSound;
    public static AudioSource _bombSource;
    public static AudioClip _bombSound;

    //Pitch and Volume Settings
    public static float cherryVolume = 0.25f;
    public static float cherryPitch = 2.0f;
    public static float bananaVolume = 0.1f;
    public static float bananaPitch = 2.0f;
    public static float watermelonVolume = 0.25f;
    public static float watermelonPitch = 1.0f;
    
    private void Awake()
    {
        // Updating static references
        _fruitSource = fruitSource;
        _cherrySound = cherrySound;
        _bananaSound = bananaSound;
        _watermelonSound = watermelonSound;
        _bombSource = bombSource;
        _bombSound = bombSound;

        // If editor audio manager exists, destroy it
        if (GameObject.FindWithTag("EditorAudio") != null)
        {
            Destroy(GameObject.FindWithTag("EditorAudio"));
        }
    }

    /*
     * This is an example of Contravariance because the class passed into
     * this method is a derived class of Fruit rather than the Fruit class
     * itself.
     */
    public static void Play(Fruit f)
    {

        if (f.GetType() == typeof(Watermelon))  { PlayWatermelon(); }
        else if (f.GetType() == typeof(Banana)) { PlayBanana(); }
        else if(f.GetType() == typeof(Cherry))  { PlayCherry(); }
        else { return; } // don't play a sound 

        _fruitSource.Play();
    }

    /*
     * Plays bomb explosion.
     */
    public static void PlayBomb()
    {
        _bombSource.clip = _bombSound;
        _bombSource.Play();
    }

    private static void PlayCherry()
    {
        // Setting values appropriate to this clip
        _fruitSource.volume = cherryVolume;
        _fruitSource.pitch = cherryPitch;
        _fruitSource.clip = _cherrySound;
    }

    private static void PlayBanana()
    {
        // Setting values appropriate to this clip
        _fruitSource.volume = 0.1f;
        _fruitSource.pitch = 2.0f;
        _fruitSource.clip = _bananaSound;
    }

    private static void PlayWatermelon()
    {
        // Setting values appropriate to this clip
        _fruitSource.volume = 0.25f;
        _fruitSource.pitch = 1.0f;
        _fruitSource.clip = _watermelonSound;
    }
}
