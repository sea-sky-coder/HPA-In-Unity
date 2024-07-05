using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSGame.Tools
{
    /// <summary>
    /// ��̬��������
    /// </summary>
    public class StaticTools
    {

        /// <summary>
        /// ���ַ���λ�����±�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Ҫ���ҵ�����</param>
        /// <param name="e">Ҫ�����Ԫ��</param>
        /// <param name="order">ָʾ����Ϊ˳��(��С����)��������(�Ӵ�С)����,Ĭ��˳��(true)</param>
        /// <param name="start">��ʼ��λ�±�</param>
        /// <param name="end">��ֹ��λ�±�,������ʾ���鳤��</param>
        /// <returns>����ֵ��ʾӦ��������±�,-1��ʾ����ʧ��</returns>
        public static int DichotomyIndex<T>(List<T> array, T e, bool order = true, int start = 0, int end = -1) where T : IComparer<T>
        {
            if (end < 0) end = array.Count;

            if (end == start) return start;
            else if (end < start) return -1;

            int index = (start + end) / 2;

            if (e.Compare(e, array[index]) > 0)
            {
                if (order) start = index + 1;
                else end = index;
            }
            else
            {
                if (order) end = index;
                else start = index + 1;
            }

            return DichotomyIndex(array, e, order, start, end);
        }

        /// <summary>
        /// ��ȡ��������ȱ�ٵ���Сֵ
        /// </summary>
        /// <param name="set">Ҫ���ҵļ���</param>
        /// <param name="min">�޶����ҵ���Сֵ</param>
        /// <returns>������ȱ�ٵ���Сֵ</returns>
        public static int GetMinLack(SortedSet<int> set, int min = 0)
        {
            if (set.Count == 0 || set.Min > min) return min;
            if (set.Max < min) return min;

            if (1f > (set.Max - set.Min) / (float)set.Count) return set.Max + 1;

            int value = min;
            foreach(int i in set)
            {
                if (i < value) continue;
                if (value == i) value++;
                else return value;
            }

            return set.Max + 1;
        }

    }

}