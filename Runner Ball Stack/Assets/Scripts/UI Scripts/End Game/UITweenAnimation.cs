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
    bool _textAnimLAunched = false;

    public IEnumerator Animate()
    {
        int amount = diamondData.levelScore / 15;
        amount = Mathf.Clamp(amount, 10, 30);
        Vector2 starterPos = Vector3.zero;
        int radius = 200;
        GameObject gem = null;

        for (int i = 0; i < amount; i++)
        {
            InstantiateGem(gem, starterPos, radius);
            yield return new WaitForEndOfFrame();
        }
    }

    void InstantiateGem(GameObject gem, Vector2 starterPos, int radius)
    {
        starterPos = GetInstantiatePos(starterPos, radius);
        gem = Instantiate(diamond, starterPos, Quaternion.identity, parent);
        gem.transform.DOMove(target.position, duration).SetEase(ease).OnComplete(() =>
        {
            Destroy(gem);
            StartScoreAnim();
        });
    }
    Vector2 GetInstantiatePos(Vector2 starterPos, int radius)
    {
        starterPos = new Vector2(start.position.x, start.position.y) + (Random.insideUnitCircle * radius);
        return starterPos;
    }

    void StartScoreAnim()
    {
        if (!_textAnimLAunched)
            StartCoroutine(ScoreManager.Instance.AnimateToNewScore());
        _textAnimLAunched = true;
    }
}
