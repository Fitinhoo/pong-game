using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformCollision : MonoBehaviour
{
    #region <--- VARIABLES --->
    [SerializeField] private LayerMask layerToCollide;
    [SerializeField] private GameObject impactEffectPrefab = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void OnCollisionEnter(Collision other)
    {
        if (layerToCollide == (1 << other.gameObject.layer))
        {
            if (impactEffectPrefab != null)
                InstantiateImpactEffect(other);

            OnCollision(other);
        }
            
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    protected virtual void OnCollision(Collision other)
    {
        Vector3 normalCollision = new Vector3(other.contacts[0].normal.x, other.contacts[0].normal.y, 0);
        BallBehavior.Instance.ReverseMotion(normalCollision);
    }


    private void InstantiateImpactEffect(Collision other)
    {
        GameObject obj = Instantiate(impactEffectPrefab, other.contacts[0].point, Quaternion.identity);
        obj.transform.up = new Vector2(other.contacts[0].normal.x, other.contacts[0].normal.y);
        obj.GetComponent<ParticleSystem>().Play();
        Destroy(obj, 2f);
    }


    #endregion
}
