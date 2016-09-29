using UnityEngine;
using System.Collections;

public class CollectablesScript : MonoBehaviour {

	void onEnable(){
		Invoke("DestroyCollectable",6f);
	}

	void DestroyCollectable(){
		gameObject.SetActive(false);
	}
}
