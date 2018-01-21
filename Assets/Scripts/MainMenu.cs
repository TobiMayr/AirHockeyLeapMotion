using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public GameObject levelButtonContainer;
    public Text pointsText;

    public Transform leftMenu;
    public Transform middleMenu;
    public Transform rightMenu;
    private Transform currentMenu;
    List<Transform> menuList;

    private const float CAMERA_TRANSITION_SPEED = 3;
    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;

    private Vector2 touchPosition;
    private float swipeResistance = 200f;

    private void Start()
    {
        cameraTransform = Camera.main.transform;

        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach(Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtonContainer.transform, false);
        }
        currentMenu = middleMenu;
        menuList = new List<Transform>();
        menuList.Add(leftMenu);
        menuList.Add(middleMenu);
        menuList.Add(rightMenu);
    }

    private void Update()
    {
        Debug.Log(cameraDesiredLookAt.rotation);
        if (cameraDesiredLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, CAMERA_TRANSITION_SPEED * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            if(Mathf.Abs(swipeForce) > swipeResistance)
            {
                if(swipeForce < 0)
                {
                    for(int i = 1; i < menuList.Count; i++)
                    {
                        if(currentMenu == menuList[i])
                        {
                            LookAtMenu(menuList[i - 1]);
                        }
                    }
                    Debug.Log("left");
                }
                else
                {
                    for (int i = 0; i < menuList.Count - 1; i++)
                    {
                        if (currentMenu == menuList[i])
                        {
                            LookAtMenu(menuList[++i]);
                        }
                    }
                    Debug.Log("right");
                }
            }
        }
    }

    public void LoadMatchMode()
    {
        GameManager.selectedMode = GameManager.GameMode.Match;
        SceneManager.LoadScene("Scene");
    }

    public void LoadArcadeMode()
    {
        GameManager.selectedMode = GameManager.GameMode.Arcade;
        SceneManager.LoadScene("Scene");
    }

    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform;
        currentMenu = menuTransform;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
