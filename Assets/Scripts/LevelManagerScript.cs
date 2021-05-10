using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    //Diðer scriptlerde eriþmek kolay olsun diye
    public static LevelManagerScript instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;
    public CinemachineVirtualCameraBase cam;
    public Transform fog;
    public Transform player;
    public Animator transition;
    public rippleproc rippleEffect;
    public bool isDialogueStarted = false;

    private void Awake()
    {
        instance = this;
    }

    public GameObject Respawn()
    {
        GameObject Player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = Player.transform;
        player = Player.transform;
        rippleEffect.playerPos = Player.transform;
        return Player;
    }
    private void Update()
    {
        if (fog != null)
        {
            fog.position = new Vector2(player.position.x, fog.position.y);
        }
    }
    public void GotoNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void GotoScene(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
        if (levelIndex == 2)
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.PlaySound("level2");
        }
        if (levelIndex == 3)
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.PlaySound("level3");
        }
    }
    public void UpdateRespawnPoint(Transform newRespawn)
    {
        respawnPoint = newRespawn;
    }
}
