using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.View.Dashboard
{
    public class PositionDataTemperatura
    {
        private string x;

        private float y;

        public PositionDataTemperatura(
            string x,
            float y)
        {
            this.x = x;
            this.y = y;
        }

        public string X => x;

        public float Y => y;
    }
}