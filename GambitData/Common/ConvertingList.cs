namespace GambitData.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The converting list.
    /// </summary>
    /// <typeparam name="TIn">
    /// </typeparam>
    /// <typeparam name="TOut">
    /// </typeparam>
    public class ConvertingList<TIn, TOut> : IList<TOut>
    {
        /// <summary>
        /// The get list.
        /// </summary>
        readonly Func<IList<TIn>> getList;

        /// <summary>
        /// The to outer.
        /// </summary>
        readonly Func<TIn, TOut> toOuter;

        /// <summary>
        /// The to inner.
        /// </summary>
        readonly Func<TOut, TIn> toInner;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConvertingList{TIn,TOut}"/> class.
        /// </summary>
        /// <param name="getList">
        /// The get list.
        /// </param>
        /// <param name="toOuter">
        /// The to outer.
        /// </param>
        /// <param name="toInner">
        /// The to inner.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public ConvertingList(Func<IList<TIn>> getList, Func<TIn, TOut> toOuter, Func<TOut, TIn> toInner)
        {
            if (getList == null || toOuter == null || toInner == null)
            {
                throw new ArgumentNullException();
            }

            this.getList = getList;
            this.toOuter = toOuter;
            this.toInner = toInner;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        IList<TIn> List { get { return this.getList(); } }

        /// <summary>
        /// The to inner.
        /// </summary>
        /// <param name="outer">
        /// The outer.
        /// </param>
        /// <returns>
        /// The <see cref="TIn"/>.
        /// </returns>
        TIn ToInner(TOut outer) { return this.toInner(outer); }

        /// <summary>
        /// The to outer.
        /// </summary>
        /// <param name="inner">
        /// The inner.
        /// </param>
        /// <returns>
        /// The <see cref="TOut"/>.
        /// </returns>
        TOut ToOuter(TIn inner) { return this.toOuter(inner); }

        #region IList<TOut> Members

        /// <summary>
        /// The index of.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int IndexOf(TOut item)
        {
            return this.List.IndexOf(this.toInner(item));
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Insert(int index, TOut item)
        {
            this.List.Insert(index, this.ToInner(item));
        }

        /// <summary>
        /// The remove at.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        public void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="TOut"/>.
        /// </returns>
        public TOut this[int index]
        {
            get
            {
                return this.ToOuter(this.List[index]);
            }
            set
            {
                this.List[index] = this.ToInner(value);
            }
        }

        #endregion

        #region ICollection<TOut> Members

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Add(TOut item)
        {
            this.List.Add(this.ToInner(item));
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.List.Clear();
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Contains(TOut item)
        {
            return this.List.Contains(this.ToInner(item));
        }

        /// <summary>
        /// The copy to.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <param name="arrayIndex">
        /// The array index.
        /// </param>
        public void CopyTo(TOut[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
        {
            get { return this.List.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.List.IsReadOnly; }
        }

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>The result of the removal</returns>
        public bool Remove(TOut item)
        {
            return this.List.Remove(this.ToInner(item));
        }

        #endregion

        #region IEnumerable<TOut> Members

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var item in this.List)
                yield return this.ToOuter(item);
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
