using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMenu : MonoBehaviour
{
    public GameObject DeathScene;
    public GameObject PauzeMenu;
    bool ifDead = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ifDead == false){
            PauzeGame();
        }
    }
    public void SetDeathActive()
    {
        ifDead = true;
        DeathScene.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PauzeGame()
    {
        PauzeMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
    }
    public void UnPauzeGame()
    {
        PauzeMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    public void ExitPauzedGame()
    {
        SceneManager.LoadScene(0);
    }
}
