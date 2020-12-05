using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    public Path Path;
    public float Speed = 1f;
    public float Hp = 5;

    public float m_ReachTargetThreshold = 0.01f;

    private Case m_TargetTile;

    public bool IsDead;


    private void Start()
    {

        m_TargetTile = Path.GetNextTile(null);
        transform.position = m_TargetTile.transform.position;

        m_TargetTile = Path.GetNextTile(m_TargetTile);
    }

    private void Update()
    {
        if (m_TargetTile == null)
        {
            //Die();
            return;
        }

        Vector3 t_TargetDirection = m_TargetTile.transform.position - transform.position;
        Vector3 t_Move = t_TargetDirection.normalized * Speed * Time.deltaTime;

        if (t_Move.sqrMagnitude + m_ReachTargetThreshold >= t_TargetDirection.sqrMagnitude)
        {
            transform.position = m_TargetTile.transform.position;
            m_TargetTile = Path.GetNextTile(m_TargetTile);
        }
        else
        {
            transform.position += t_Move;
        }
    }

    /*public void Die()
    {
        IsDead = true;
        Destroy(this.gameObject);
        Instantiate(PREFAB_DeathSound, transform.position, Quaternion.identity);
    }

    public void TakeDamage(float a_Damage)
    {
        Hp -= a_Damage;

        if (Hp <= 0)
            Die();
    }*/

    private void OnDrawGizmos()
    {
        if (Path == null || Path.Checkpoints.Count < 2)
            return;



        Gizmos.color = Color.cyan;



        for (int i = 0; i < Path.Checkpoints.Count - 1; i++)
        {
            Gizmos.DrawLine(Path.Checkpoints[i].transform.position, Path.Checkpoints[i + 1].transform.position);
        }
    }
}
