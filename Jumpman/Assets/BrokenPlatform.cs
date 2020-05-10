using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool collided = false;
    
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        Debug.Log("Here");
    }

    public void StartAnim()
    {
        anim.Play("Collision");
        Invoke("DestroyPlatform", 0.40f);
     
    }

    private void DestroyPlatform()
    {
        Destroy(anim);
        Destroy(gameObject);
    }
}
