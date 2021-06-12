using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public string load;
<<<<<<< HEAD
    
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
>>>>>>> 5f4a60e7a35b677755cca13bd084c871408f7a16
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(load);
<<<<<<< HEAD
            StartCoroutine(Coroutine());
        }
    }

    private void OnMouseDown()
    {
        transform.GetComponent<Animator>().Play("Base Layer.Roll");
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(load);
    }
}
=======
        }
    }
}
>>>>>>> 5f4a60e7a35b677755cca13bd084c871408f7a16
