using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void MoveScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void OnClickQuit()
    {
        // Application.Quit();  // 이거는 빌드해야 나가기 가능


        
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        
    }


}
