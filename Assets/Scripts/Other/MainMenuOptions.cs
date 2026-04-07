using UnityEngine;

public class MainMenuOptions : MonoBehaviour
{
    //USED FOR THE MAIN MENU NOTHING ELSE AT THE MOMENT IF YOU NEED TO USE THIS FOR SOMETHING ELSE IT MAY NOT WORK 
    //ASK TALON BEFORE USE
    //still reusing code from a previous menu its just easier this way

    [SerializeField] GameObject optionsMenu;

    public bool paused;
    public float cooldown;

    public void Options()
    {
        optionsMenu.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    public void BackOptions()
    {
        optionsMenu.SetActive(false);
        paused = true;
        Time.timeScale = 1f;

    }

}
