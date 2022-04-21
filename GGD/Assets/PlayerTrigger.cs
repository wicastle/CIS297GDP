using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    public MeshRenderer playerMesh1;
    public MeshRenderer playerMesh2;
    public Material deathMat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Dead");

            StartCoroutine(DeathSequence(1));
        }
    }

    IEnumerator DeathSequence(float time)
    {
        playerMesh1.material = deathMat;
        playerMesh2.material = deathMat;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("SampleScene");
    }
}
