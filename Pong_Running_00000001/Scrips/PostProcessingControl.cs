using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostProcessingControl : MonoBehaviour
{
    [SerializeField]private PostProcessVolume _postProcessVolume;
    private ChromaticAberration _chromaticAberration;
    private LensDistortion _lensDistortion;

    private float _maxIntensivityChromaticAberration;
    private float _maxIntensivityLensDistortion;

    [Range(0f, 1f)] [SerializeField]private float _speed;

    void Start()
    {
        if (_postProcessVolume == null)
        {
            _postProcessVolume = GetComponent<PostProcessVolume>();
        }
        _postProcessVolume.profile.TryGetSettings(out _chromaticAberration);
        _postProcessVolume.profile.TryGetSettings(out _lensDistortion);
        _maxIntensivityChromaticAberration = _chromaticAberration.intensity.value;
        _maxIntensivityLensDistortion = _lensDistortion.intensity.value;
        _chromaticAberration.intensity.value = 0f;
        _lensDistortion.intensity.value = 0f;

    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            
           

            if (_touch.phase == TouchPhase.Stationary)
            {
                OnMove();
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                OffMove();
            }
        }
    }
    private void OnMove()
    {
        _chromaticAberration.active = true;
        _lensDistortion.active = true;
        _chromaticAberration.intensity.value = Mathf.Lerp(_chromaticAberration.intensity.value, _maxIntensivityChromaticAberration, _speed);
        _lensDistortion.intensity.value = Mathf.Lerp(_lensDistortion.intensity.value, _maxIntensivityLensDistortion, _speed);


    }

    private void OffMove()
    {
        _chromaticAberration.intensity.value = Mathf.Lerp(_chromaticAberration.intensity.value, 0f, _speed);
        _lensDistortion.intensity.value = Mathf.Lerp(_lensDistortion.intensity.value, 0f, _speed);
        _chromaticAberration.active = false;
        _lensDistortion.active = false;
        
    }

}
