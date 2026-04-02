using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutscenePlayer : MonoBehaviour
{
    public VideoPlayer video;

    public startGameScript startGameScript;
    public GameObject player;

    public GameObject videoScreen;
    private void Awake()
    {
        videoScreen.SetActive(false);
    }
    public void play()
    {
        videoScreen.SetActive(true);
        video.Play();
        video.loopPointReached += Video_loopPointReached;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == player.name)
        {
            play();
        }
    }

    private void Video_loopPointReached(VideoPlayer source)
    {
        video.Stop();
        startGameScript.PlayGame();
    }

    public void StartDemo()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
