using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UITweenAnimation : MonoBehaviour
{
    [SerializeField] DiamondDataScriptable diamondData;
    [SerializeField] GameObject diamond;
    [SerializeField] Transform target;
    [SerializeField] Transform start;
    [SerializeField] Transform parent;
    [SerializeField] Ease ease;

    [SerializeField] float duration;

    public IEnumerator Animate()
    {
        int amount = diamondData.levelScore / 15;
        Debug.Log("Amount: " + amount);
        for (int i = 0; i < amount; i++)
        {
            Vector2 starterPos = new Vector2(start.position.x, start.position.y) + (Random.insideUnitCircle * 200f);
            GameObject gem = Instantiate(diamond, starterPos, Quaternion.identity, parent);
            gem.transform.DOMove(target.position, duration).SetEase(ease).OnComplete(() =>
            {
                Destroy(gem);
                StartCoroutine(ScoreManager.Instance.AnimateToNewScore());
            });
            yield return new WaitForEndOfFrame();
        }
    }

}
