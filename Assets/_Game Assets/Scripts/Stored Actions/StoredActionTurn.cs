using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoredActionTurn : StoredAction
{
    /// <summary>
    /// Turn around, entity character player pakenya false isrepeat angle lho
    /// </summary>
    /// <param name="entity">Entity character</param>
    /// <param name="yDegree">The angle dumbass</param>
    /// <param name="isRepeatAngle">true --> 0, 90, 180, 270. false --> 0, 90, 180, -90</param>
    public StoredActionTurn(EntityCharacter entity, float yDegree, bool isRepeatAngle = true)
    {
        Vector3 euler = new Vector3(0.0f, _ConvertTo90Degrees(yDegree, isRepeatAngle), 0.0f);
        action = () =>
        {
            actionHasDone = !_CheckAbleToTurn(entity) || _CheckIsBetweenAngle(entity.transform.rotation.eulerAngles.y, yDegree - 15, yDegree + 15, isRepeatAngle);
            if (actionHasDone)
            {
                entity.transform.rotation = Quaternion.Euler(euler);
                return;
            }

            entity.transform.rotation = Quaternion.Slerp(entity.transform.rotation, Quaternion.Euler(euler), 10f * Time.deltaTime);
        };
    }

    private bool _CheckAbleToTurn(EntityCharacter entity)
    {
        var disableMoveInputList = entity.storedStatusEffects.OfType<StoredStatusEffectCaptured>();
        foreach (var effect in disableMoveInputList)
        {
            if (effect.disableTurn)
                return false;
        }

        return true;
    }

    private bool _CheckIsBetweenAngle(float value, float min, float max, bool isRepeat)
    {
        float newValue = (isRepeat) ? value : (value > 180) ? value - 360 : value;
        if (isRepeat && min <= 0)
            return (newValue >= 360 + min && newValue < 360) || newValue < max;

        if (!isRepeat && max >= 180)
            return newValue >= min || (newValue < max - 360 && newValue >= -180);

        return newValue >= min && newValue < max;
    }

    private float _ConvertTo90Degrees(float value, bool isRepeat = true)
    {
        if (isRepeat)
        {
            if (value >= 315.0f && value < 45.0f) return 0.0f;
            if (value >= 45.0f && value < 135.0f) return 90.0f;
            if (value >= 135.0f && value < 225.0f) return 180.0f;
            if (value >= 225.0f && value < 315.0f) return 270.0f;
        }
        else
        {
            if (value >= -45.0f && value < 45.0f) return 0.0f;
            if (value >= 45.0f && value < 135.0f) return 90.0f;
            if (value <= -45.0f && value > -135.0f) return -90.0f;
            if (value <= -135.0f || value > 135.0f) return 180.0f;
        }
        return 0.0f;
    }
}
