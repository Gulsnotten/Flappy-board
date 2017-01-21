using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores {
    static int[] m_scores;
    static int m_winScore;

    public static void Reset(int p_playerCount, int p_winScore)
    {
        m_winScore = p_winScore;

        m_scores = new int[p_playerCount];
        for (int i = 0; i < m_scores.Length; i++) {
            m_scores[i] = 0;
        }
    }

    public static int GetPlayerScore(int p_index)
    {
        return m_scores[p_index];
    }

    public static bool AddScore(int p_index)
    {
        int s = ++m_scores[p_index];

        return s >= m_winScore;
    }
    public static int GetWinner()
    {
        for (int i = 0; i < m_scores.Length; i++) {
            if (m_scores[i] >= m_winScore) {
                return i;
            }
        }

        return 0;
    }
}
