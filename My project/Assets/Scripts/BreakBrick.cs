using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    private bool is_broken=false;
    public  GameObject prefab; 
    // A reference to the “debris” prefab
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void  OnTriggerEnter2D(Collider2D col){
	if (col.gameObject.CompareTag("Mario") &&  !is_broken){
		is_broken  =  true;
        // prefab.SetActive(true);
		// assume we have 5 debris per box
		for (int x =  0; x<5; x++){
			Instantiate(prefab, transform.position, Quaternion.identity);
		}
		gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled  =  false;
		gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled  =  false;
		GetComponent<EdgeCollider2D>().enabled  =  false;
	}
}
}
