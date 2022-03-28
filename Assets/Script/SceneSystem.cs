using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class SceneSystem : MonoBehaviour
{
    public void A_SceneManager(int index)
    {
        SceneManager.LoadScene(index);
    }
}