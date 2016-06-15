using System;
using Windows.UI.Xaml.Media;

namespace SplitViewTemplate.Modules.MainFrame.Model
{
    public class NaviListModel
    {
        public Geometry Icon { get; set; }

        public string Text { get; set; }

        public Type PageType { get; set; }
    }
}
