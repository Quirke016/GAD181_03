using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Cup : MonoBehaviour
{
  
    public bool ballUnderThis = false;
    public bool ballSelected = false;
    public bool showTime = false;
    public bool selectTime = false;
    public bool testing = false;
    SpriteRenderer m_SpriteRenderer;
    public Sprite cupUp;
    public Sprite cupDown;

    public bool beingRevaled;





    IEnumerator RevealBehind()
    {
        /*m_SpriteRenderer.color = new Color(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, 0.5f);

        while (true) { }
        yield return new WaitForSeconds(duration / loopCount);*/

        StartCoroutine(FadeOutMaterial(this.gameObject, 1f, 0.25f, 1f));
        yield return new WaitForSeconds(1.25f);
        StartCoroutine(FadeOutMaterial(this.gameObject, 0.25f, 1f, 1f));
    }


    IEnumerator FadeOutMaterial(GameObject objectToFade, float fadeSpeed, float targetOpacity, float duration)
    {
        Renderer rend = objectToFade.GetComponent<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = matColor.a;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            alphaValue = Mathf.Lerp(alphaValue, targetOpacity, Time.deltaTime / fadeSpeed);
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, targetOpacity);
    }




 



    public GameObject ballPrefab;
    GameObject ballGameObject;




    // Start is called before the first frame update
    void Start()
    {
        testing = false;

        m_SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();


        // Create a clone of the ball for the perfab
        ballGameObject = Instantiate(ballPrefab);


    }






    // Update is called once per frame
    void Update()
    {
        /*if (ballUnderThis)
        {
            
        }*/
        ballGameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0.5f);



        // Get the material of the object
        Material ballMaterial = ballGameObject.GetComponent<Renderer>().material;

        if (ballUnderThis)
        {
            
            // Set the alpha value of the material
            Color color = ballMaterial.color;
            color.a = 1f; // Set the alpha value to 50%
            ballMaterial.color = color;

            //ballGameObject.GetComponent<SpriteRenderer>().color.a = 1f;
        }
        else
        {
            // Set the alpha value of the material
            Color color = ballMaterial.color;
            color.a = 0f; // Set the alpha value to 50%
            ballMaterial.color = color;

            //ballGameObject.GetComponent<SpriteRenderer>().color.a = 0f;
        }


        if (!selectTime)
        {
            ballSelected = false;
        }


        if (ballUnderThis && !showTime && !selectTime)
        {
            m_SpriteRenderer.sprite = cupUp;
            m_SpriteRenderer.color = new Color(1f, 1f, 1f);
        }
        else if (ballSelected && !showTime && selectTime)
        {
            m_SpriteRenderer.color = new Color(0f, 0f, 0f);
        }
        else if (ballSelected && !showTime && !selectTime)
        {
            m_SpriteRenderer.color = new Color(0f, 0f, 1f);
        }
        else
        {
            m_SpriteRenderer.sprite = cupDown;
            //m_SpriteRenderer
            m_SpriteRenderer.color = Color.white;
            //.material.SetColor("_Color", Color.white);
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = cupDown;
        }
    


        if (Input.GetKeyDown(KeyCode.M) && (!showTime && selectTime)) // && ballSelected
        {
            StartCoroutine(RevealBehind());

        }


    }
}
