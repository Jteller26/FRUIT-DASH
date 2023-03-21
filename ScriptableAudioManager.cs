using UnityEngine;

/*
 *  Custom scriptable object to hold default sound effect files. To allow
 *  the restoration of default sounds during runtime when file sounds have been changed. A 
 *  way this is useful for development is for comparison of new sounds to old sounds when looking
 *  to replace sound effects (during runtime within the editor).
 */

[CreateAssetMenu(fileName = "ScriptableAudioManager", menuName = "Custom Scriptable Objects/AudioManager")]
public class ScriptableAudioManager : ScriptableObject
{
    public AudioClip cherrySound;
    public AudioClip bananaSound;
    public AudioClip watermelonSound;
    public AudioClip bombSound;
    
}
