using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Vignettepost : MonoBehaviour
{
    //makes the vignette of postprocessing to move in aand out while playing
    Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        vignette = GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        vignette.intensity.value = Mathf.Sin(Time.time);
    }
}
