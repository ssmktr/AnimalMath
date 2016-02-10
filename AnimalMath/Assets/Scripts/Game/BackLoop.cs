using UnityEngine;
using System.Collections;

public class BackLoop : MonoBehaviour {
	private Material m_mBack;
	private float m_fOffsetX = 0.0f;
	public float m_fLoopSpeed = 0.5f;
	void Start () {
		m_mBack = this.GetComponent<Material> ();
	}
	
	void Update () {
		m_fOffsetX += m_fLoopSpeed * Time.deltaTime;
		if (1 < m_fOffsetX) {
			m_fOffsetX -= 1;
		}
		this.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2 (m_fOffsetX, 0.0f);
	}
}
