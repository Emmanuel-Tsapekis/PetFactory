using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	[SerializeField] private GameObject blood;
	[SerializeField]
	private TextMesh cuteCountText;
	[SerializeField]
	private TextMesh uglyCountText;
	[SerializeField]
	private int cuteCount;
	[SerializeField]
	private int uglyCount;
	[SerializeField]
	private GameObject YOUWINOBJECT;
	private static GameManager m_Instance;
	private bool isDone = false;
	public static GameManager Instance{get{return m_Instance;}}
	// Use this for initialization
	void Awake () {
		m_Instance = this;
		cuteCountText.text = cuteCount.ToString();
		uglyCountText.text = uglyCount.ToString();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (cuteCount==0 && uglyCount==0 && YOUWINOBJECT) {
			YOUWINOBJECT.SetActive(true);
			isDone = true;
		}
		if (isDone && (Input.touchCount>0 || Input.GetMouseButtonDown(0))) {
			Application.LoadLevel(0);
		}
		//blood.SetActive(false);
	}
	public void ScorePoint(Creature creature, bool cute)
	{
		if (cute) {
			if (creature.isCute) {
				--cuteCount;
			}
			else {
				++cuteCount;
			}
			cuteCountText.text = cuteCount.ToString ();
		}
		else {
			--uglyCount;
			//blood.SetActive (true);
			uglyCountText.text = uglyCount.ToString ();
		}

		if (cuteCount==0 && uglyCount==0 && YOUWINOBJECT) {
			YOUWINOBJECT.SetActive(true);
			isDone = true;
		}
	}
}
