using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionTests
{
    [Test]
    public void CheckBallCollisionDirection_HorizontalCollision()
    {
        Reflexion reflexion = new Reflexion();
        Transform actorTransform = new GameObject().GetComponent<Transform>();

        actorTransform.right = new Vector3(1f, 1f, 0f);
        Vector3 expectedDirection = new Vector3(1f, -1f, 0f).normalized;

        reflexion.ChangeDirection(actorTransform, Vector3.up);

        Assert.That(Vector3.Distance(actorTransform.right, expectedDirection), Is.LessThan(0.0001f));
    }


    [Test]
    public void CheckBallCollisionDirection_VerticalCollision()
    {
        Reflexion reflexion = new Reflexion();
        Transform actorTransform = new GameObject().GetComponent<Transform>();

        actorTransform.right = new Vector3(1f, 1f, 0f);
        Vector3 expectedDirection = new Vector3(-1f, 1f, 0f).normalized;

        reflexion.ChangeDirection(actorTransform, Vector3.right);

        Assert.That(Vector3.Distance(actorTransform.right, expectedDirection), Is.LessThan(0.0001f));
    }
}
