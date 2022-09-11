using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Expression_2D1Bit
{
    None, Hello, Cry, Zzz, Dead, Idk, ThumbUp, Angry, Surprise
}

public abstract class EntityCharacterNPC2D1Bit : EntityCharacterNPC
{
    [SerializeField] protected Expression_2D1Bit m_startExpression = Expression_2D1Bit.None;
    [SerializeField] protected TextMesh[] m_expressionTexts;

    Dictionary<Expression_2D1Bit, string> expression = new Dictionary<Expression_2D1Bit, string>()
    {
        [Expression_2D1Bit.None]        = "",
        [Expression_2D1Bit.Hello]       = "( ^_^)／",
        [Expression_2D1Bit.Cry]         = "((╥╯⌒╰╥๑))",
        [Expression_2D1Bit.Zzz]         = "( ︶｡︶✽)",
        [Expression_2D1Bit.Dead]        = "(✖﹏✖)",
        [Expression_2D1Bit.Idk]         = "╮(╯∀╰)╭",
        [Expression_2D1Bit.ThumbUp]     = "(･ω･)b",
        [Expression_2D1Bit.Angry]       = "（＞д＜）",
        [Expression_2D1Bit.Surprise]    = "(⊙︿⊙ ✿)",
    };

    public void SetExpression(Expression_2D1Bit switchExpression)
    {
        for (int i = 0; i < m_expressionTexts.Length; i++)
        {
            m_expressionTexts[i].text = expression[switchExpression];
        }
    }
}
