using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldTest
{
    public class Color
    {
        public string Name { get; set; }
    }

    class AllColors : IEnumerable
    {
        Color[] _colors =
        {
            new Color() { Name = "red" },
            new Color() { Name = "blue" },
            new Color() { Name = "green" }
        };

        public IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(_colors);
        }

        private class ColorEnumerator : IEnumerator
        {
            private Color[] _colors;
            int _position;

            public ColorEnumerator(Color[] colors)
            {
                this._colors = colors;
                this._position = -1;
            }
            public object Current
            {
                get
                {
                    return _colors[_position];
                }
            }

            public bool MoveNext()
            {
                _position++;
                if (_position >= _colors.Length)
                    return false;

                return true;
            }

            public void Reset()
            {
                _position = -1;
            }
        }
    }
}
