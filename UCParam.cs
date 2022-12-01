using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Portfolio_Optimization
{
    public partial class UCParam : UserControl
    {
        # region Delegates/Events
        public delegate void RefreshDelegate(object sender, eventsMsg msg);
        public event RefreshDelegate onRefreshEvent;
        #endregion

        public string Name;
        public double Value;
        public UCParam()
        {
            InitializeComponent();
        }

        public void getValue(out string N, out double V)
        {
            N = chkName.Text.ToString();
            Name = N;
            V = Convert.ToDouble(txtValue.Text);
            Value = V;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (onRefreshEvent != null)
            {
                var et = new EventType(); et = EventType.remove;
                var e2 = new eventsMsg();
                e2.label = this.Name;
                e2.eventType = et;
                onRefreshEvent(this, e2);

            }
        }

        private void chkName_TextChanged(object sender, EventArgs e)
        {
            Name = chkName.Text;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            Value = double.Parse(txtValue.Text);
        }

        
    }
    public enum EventType
    {
        valueChange, remove, add
    }
    public class eventsMsg
    {
        public string label; //English Name
        public string DBID;
        public int GroupCode;
        public int ItemCode;
        public EventType eventType;
        public int leftVal;
        public int rightVal;

    }
}
