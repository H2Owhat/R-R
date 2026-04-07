using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] AudioSource bgMusicSource;
    [SerializeField] AudioSource pauseMenuSong;
    public bool paused;
    public float cooldown;

    public void Awake() {
        paused = false;
        bgMusicSource.mute = false;
        pauseMenuSong.mute = true;
        Resume();
        cooldown = 0;
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        bgMusicSource.mute = true;
        pauseMenuSong.mute = false;
        paused = true;
        Time.timeScale = 0f;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        bgMusicSource.mute = false;
        pauseMenuSong.mute = true;
        paused = false;
        Time.timeScale = 1f;

    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        bgMusicSource.mute = true;
        pauseMenuSong.mute = false;
        paused = true;
        Time.timeScale = 0f;
    }

    public void BackOptions()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        bgMusicSource.mute = true;
        pauseMenuSong.mute = false;
        paused = true;
        Time.timeScale = 0f;

    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuScene");
    }
}
