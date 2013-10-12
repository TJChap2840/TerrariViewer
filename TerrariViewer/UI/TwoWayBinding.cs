using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace TerrariViewer.UI
{
    public class TwoWayBinding : Binding
    {
        public TwoWayBinding()
        {
            Initialize();
        }

        public TwoWayBinding(string path)
            : base(path)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Mode = BindingMode.TwoWay;
            this.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }

    }
}
