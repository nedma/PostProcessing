using System.Collections.Generic;

namespace UnityEngine.Experimental.PostProcessing
{
    class TargetPool
    {
        readonly List<int> m_Pool;
        int m_Current;

        internal TargetPool()
        {
            m_Pool = new List<int>();
        }

        internal int Get()
        {
            int ret = Get(m_Current);
            m_Current++;
            return ret;
        }

        int Get(int i)
        {
            int ret;

            if (m_Pool.Count > i)
            {
                ret = m_Pool[i];
            }
            else
            {
                // Avoid discontinuities
                while (m_Pool.Count <= i)
                    m_Pool.Add(Shader.PropertyToID("_TargetPool" + i));

                ret = m_Pool[i];
            }

            return ret;
        }

        internal void Reset()
        {
            m_Current = 0;
        }
    }
}
