using UnityEngine;
using UnityEngine.Video;

public class ADS : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private ResurrectionUI _resurectionUI;

    private void Start()
    {
        _videoPlayer.loopPointReached += OnVideoFinished;
    }
    
    private void OnDestroy()
    {
        _videoPlayer.loopPointReached -= OnVideoFinished;
    }
    
    private void OnVideoFinished(VideoPlayer source)
    {   
        gameObject.SetActive(false);
        _resurectionUI.ResumeGame();
        _resurectionUI.gameObject.SetActive(false);
    }
    
}
