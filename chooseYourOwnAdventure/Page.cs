using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
namespace chooseYourOwnAdventure
{
    internal class Page
    {

        public string[] outputLabelTexts = new string[] { };
        public int[] pathOptions = new int[] { };
        public Image image;
        public Page(string[] _outputLabelTexts, int[] _pathOptions, Image _image)
        {
            outputLabelTexts = _outputLabelTexts;
            pathOptions = _pathOptions;
            image = _image;
        }
    }
}
