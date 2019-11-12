//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: LinePairCollection.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ParallelMorph
{
	[Serializable]
	public class LinePairCollection : Collection<Tuple<Line,Line>>
	{
        [NonSerialized]
        private Tuple<Line, Line> _selected;

        public LinePairCollection() {}
        public LinePairCollection(IList<Tuple<Line, Line>> source) : base(source) { }

        protected override void InsertItem(int index, Tuple<Line, Line> item)
        {
            base.InsertItem(index, item);
            _selected = item;
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            if (Count > 0) _selected = this[0];
            else _selected = null;
        }

        public Tuple<Line, Line> Selected { get { return _selected; } set { _selected = value; } }

		public void SelectFirst()
		{
			if (Count > 0) _selected = this[0];
		}

		public void SelectLast()
		{
            if (Count > 0) _selected = this[Count - 1];
		}

		public void SelectNext()
		{
			MoveToNextLine(1);
		}

		public void SelectPrev()
		{
			MoveToNextLine(-1);
		}

		private void MoveToNextLine(int skip)
		{
			if (Count > 0) 
			{
				if (_selected == null) SelectFirst();
				else
				{
					int index = IndexOf(_selected);
					if (index >= 0) 
					{
						index = index + skip;
                        while(index < 0) index += Count;
                        index %= Count;
						_selected = this[index];
					}
					else SelectFirst();
				}
			}
		}
    }
}