using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseClasses;
namespace Portfolio_Optimization
{
    public partial class FormSelectDecisionMaker : Form
    {
        private List<Symbols> FinalSymbols;
        private Indicator ind;
        private List<UCParam> UCP = new List<UCParam>();
        public Indicator getResult()
        {
            return ind;
        }
        public FormSelectDecisionMaker()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // get  from combox box and text boxes:
            
            List<Parameter> ParamList = new List<Parameter>();
            int i=0;
            foreach(var a in tableLayoutPanel1.Controls)
            {
                UCParam newP = new UCParam();
                newP = (UCParam)a;
                ParamList.Add(new Parameter(i, newP.Name, newP.Value));
                i++;
            }

            ind = new Indicator(chkIndicator.Text, ParamList);
            //ind.InsCode = FinalSymbols.First(t => t.Symbol == chkSymbol.Text).InsCode;
            ind.EDEven = int.Parse(txtDEven.Text);
            ind.EHEven = int.Parse(txtHEven.Text);
            ind.SDEven = int.Parse(txtSDEven.Text);
            ind.SHEven = int.Parse(txtSHEven.Text);
            ind.MPeriod = int.Parse(txtMPeriod.Text);
            ind.Scope = int.Parse(chkScope.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormSelectDecisionMaker_Load(object sender, EventArgs e)
        {
            UCP = new List<UCParam>();
            UCParam newUCParam = new UCParam();
            UCP.Add(newUCParam);
            tableLayoutPanel1.Controls.Add(newUCParam);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var b1 = new UCParam();
            b1.onRefreshEvent += new UCParam.RefreshDelegate(P1_onRefreshEvent);
            UCP.Add(b1);
            SynParamBox();
            tableLayoutPanel1.Refresh();
            //tableLayoutPanel1.VerticalScroll.Value = tableLayoutPanel1.Height;
        }
        
        void P1_onRefreshEvent(object sender, eventsMsg msg)
        {
            if (msg.eventType == EventType.remove)
            {
                UCP.Remove((UCParam)sender);
                SynParamBox();
            }
            else if (msg.eventType == EventType.valueChange)
            {
                this.Text = msg.leftVal + "," + msg.rightVal;

            }
        }
        private void SynParamBox()
        {
            var b1 = new UCParam();
            while (tableLayoutPanel1.Controls.Count > 0)
                tableLayoutPanel1.Controls.RemoveAt(0);

            int i = 0;
            tableLayoutPanel1.RowCount = UCP.Count;
            foreach (var c in UCP)
            {
                tableLayoutPanel1.Controls.Add(c, 0, i++);
            }

        }
    }
}
