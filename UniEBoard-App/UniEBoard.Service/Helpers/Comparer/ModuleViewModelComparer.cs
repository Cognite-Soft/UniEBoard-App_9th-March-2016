using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Helpers.Comparer
{
    public class ViewModelComparer<T> : IEqualityComparer<T>
        where T : BaseViewModel
    {
        /// <summary>
        /// This is the method which does the comparison
        /// </summary>
        /// <param name="P1">The first ModuleViewModel to compare</param>
        /// <param name="P2">The second ModuleViewModel to compare</param>
        /// <returns>Return true if there is a match for the Id
        /// else false</returns>
        public bool Equals(T m1, T m2)
        {
            if (m1.Id == m2.Id) return true;
            return false;
        }

        /// <summary>
        /// This method helps the comparison by producing the hashkey
        /// of the ID column. It is understood if the ID
        /// is same then the Module belong to the same category
        /// </summary>
        /// <param name="P">The ModuleViewModel</param>
        /// <returns>the integer hashcode</returns>
        public int GetHashCode(T m)
        {
            if (Object.ReferenceEquals(m, null)) return 0;
            int hashId = m.Id == null ? 0 : m.Id.GetHashCode();
            return hashId;
        }
    }
}
