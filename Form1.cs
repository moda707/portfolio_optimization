using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vtocSqlInterface;

using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;

using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Math;
using AForge.Controls;

using BaseClasses;

namespace Portfolio_Optimization
{
    public partial class Form1 : Form
    {        
        private List<Symbols> Symbol;
        private List<Symbols> FinalSymbol;
        private vtocSqlInterface.sqlInterface mySql;
        private string sqlCmd;
        private delegate void SetTextCallback(System.Windows.Forms.Control control, string text);
        private int OptPeriod;
        private string Scope;
        private string SDEven;
        private string SHEven;
        private string EDEven;
        private string EHEven;
        private string NetworkAddress;
        private double RiskFreeRate = 0.0001;
        private double CashAdjRet = 0.0;
        private double ExpectedVar = 0.04;
        Dictionary<string, int> SymbKeys;
        private double InitialCash;
        private int InputLayerDataCount = 41;
        private double[] Actions;
        private double RiskAversion = 10;
        Random RandomGenerator = new Random(DateTime.Now.Second);
        double BuyCost = 0.0005;
        double SellCost = 0.00001;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Symbol = new List<Symbols>();
            FinalSymbol = new List<Symbols>();

            Symbol = ReadSymbols("All").OrderBy(t => t.Symbol).ToList();            
            lstFirstSymbol.DataSource = Symbol;
            lstFirstSymbol.ValueMember = "InsCode";
            lstFirstSymbol.DisplayMember = "Symbol";
            cmbScop.SelectedItem = cmbScop.Items[2];
        }

        private List<Symbols> ReadSymbols(string type)
        {
            List<Symbols> tmpSymb = new List<Symbols>();
            tmpSymb = new List<Symbols>();

            mySql = new sqlInterface(Properties.Settings.Default.sqlserver, "AdjPrice",
                                     Properties.Settings.Default.username, Properties.Settings.Default.pass);
            DataTable dtSymbols;
            switch (type)
            {
                case "All":
                    sqlCmd = @"  SELECT DISTINCT S.LVal18AFC as Symbol, S.InsCode as InsCode
                          FROM [TseTrade].[dbo].[vwTseInstrument] S
                          JOIN TseTrade.dbo.vwTsePrice T ON T.InsCode = S.InsCode
                          WHERE S.Flow in (1,2) and YMarNSC='No' and YVal in (300 ,303)
                          ORDER BY LVal18AFC";
                    dtSymbols = mySql.SqlExecuteReader(sqlCmd);

                    foreach (DataRow row in dtSymbols.Rows)
                    {
                        if (dtSymbols.Columns.Contains("InsCode") && dtSymbols.Columns.Contains("Symbol"))
                        {
                            var sCode = row["InsCode"].ToString();
                            var sName = row["Symbol"].ToString();

                            tmpSymb.Add(new Symbols(sName, sCode));
                        }
                    }
                    break;
                case "Top50":
                    sqlCmd = "DECLARE @SDEven int = " + txtSDEven.Text + " DECLARE @EDEven int = " + txtDEven.Text;
                    sqlCmd += @" DECLARE @TTABLE Table(InsCode bigint, Volume bigint, CSecVal int)  
                            INSERT INTO @TTABLE
                            SELECT T.InsCode, SUM(T.QTotTran5J) Volume, MAX(S.CSecVal) CSecVal
                            FROM TseTrade.dbo.TsePrice T
                            JOIN TseTrade.dbo.TseInstrument S ON S.InsCode = T.InsCode
                            WHERE T.IsLastRecordDaily = 1 AND (T.DEven between @SDEven and @EDEven) AND S.YMarNSC='NO' AND S.Flow=1 AND S.YVal <> 400
                            GROUP BY T.InsCode
                            SELECT TOP 50 S.LVal18AFC Symbol, S.InsCode InsCode
                            FROM  @TTABLE T
                            JOIN TseTrade.dbo.vwTseInstrument S ON S.InsCode = T.InsCode
                            JOIN TseTrade.dbo.TseSector W ON W.CSecVal = S.CSecVal
                            ORDER BY  Volume DESC";
                    dtSymbols = mySql.SqlExecuteReader(sqlCmd);

                    foreach (DataRow row in dtSymbols.Rows)
                    {
                        if (dtSymbols.Columns.Contains("InsCode") && dtSymbols.Columns.Contains("Symbol"))
                        {
                            var sCode = row["InsCode"].ToString();
                            var sName = row["Symbol"].ToString();

                            tmpSymb.Add(new Symbols(sName, sCode));
                        }
                    }
                    break;
            }

            return tmpSymb;
        }

        private void btnoneright_Click(object sender, EventArgs e)
        {
            if (!FinalSymbol.Contains((Symbols)lstFirstSymbol.SelectedItem))
            {
                lstFinalSymbol.Items.Add((Symbols)lstFirstSymbol.SelectedItem);
                lstFinalSymbol.ValueMember = "InsCode";
                lstFinalSymbol.DisplayMember = "Symbol";
                lstFinalSymbol.SelectedIndex = lstFinalSymbol.Items.Count - 1;

                FinalSymbol.Add((Symbols)lstFirstSymbol.SelectedItem);
                SymbolCounter();
            }
        }

        private void btnoneleft_Click(object sender, EventArgs e)
        {
            FinalSymbol.Remove((Symbols)lstFinalSymbol.SelectedItem);
            lstFinalSymbol.Items.Remove((Symbols)lstFinalSymbol.SelectedItem);
            SymbolCounter();
        }

        private void SymbolCounter()
        {
            txtSymCount.Text = FinalSymbol.Count.ToString();
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            Symbol = new List<Symbols>();
            if (chkall.Checked)
            {
                if (lstFirstSymbol.Items.Count > 0)
                    lstFirstSymbol.DataSource = null;
                Symbol = ReadSymbols("All").OrderBy(t => t.Symbol).ToList();
                lstFirstSymbol.DataSource = Symbol;
                lstFirstSymbol.ValueMember = "InsCode";
                lstFirstSymbol.DisplayMember = "Symbol";
            }
        }

        private void chktop50_CheckedChanged(object sender, EventArgs e)
        {
            Symbol = new List<Symbols>();
            if (chktop50.Checked)
            {
                if (lstFirstSymbol.Items.Count > 0)
                    lstFirstSymbol.DataSource = null;
                lstFirstSymbol.Enabled = false;
                Application.DoEvents();
                Symbol = ReadSymbols("Top50").OrderBy(t => t.Symbol).ToList();
                lstFirstSymbol.DataSource = Symbol;
                lstFirstSymbol.ValueMember = "InsCode";
                lstFirstSymbol.DisplayMember = "Symbol";
                lstFirstSymbol.Enabled = true;
            }
        }

        private void btnrightall_Click(object sender, EventArgs e)
        {
            foreach (var l in Symbol)
            {
                if (!FinalSymbol.Contains(l))
                {
                    lstFinalSymbol.Items.Add(l);
                    lstFinalSymbol.ValueMember = "InsCode";
                    lstFinalSymbol.DisplayMember = "Symbol";
                    FinalSymbol.Add(l);
                }
            }
            SymbolCounter();
        }

        private void btnleftall_Click(object sender, EventArgs e)
        {
            FinalSymbol.Clear();
            lstFinalSymbol.Items.Clear();
            SymbolCounter();
        }


        private void SetText(System.Windows.Forms.Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        private void txtsymbolsearch_TextChanged(object sender, EventArgs e)
        {
            List<Symbols> tmpSymbol = new List<Symbols>();

            tmpSymbol = Symbol.FindAll(t => t.Symbol.Contains(txtsymbolsearch.Text));
            lstFirstSymbol.DataSource = tmpSymbol;
            lstFirstSymbol.ValueMember = "InsCode";
            lstFirstSymbol.DisplayMember = "Symbol";
            lstFirstSymbol.SelectedValue = "Selected";
        }
        
        private void lstFirstSymbol_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnoneright_Click(sender, e);
        }

        private void lstFinalSymbol_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnoneleft_Click(sender, e);
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string txtfile = "";
            if (openFileDialog1.FileName != "")
            {
                txtfile = System.IO.File.ReadAllText(openFileDialog1.FileName);
                //lstFinalSymbol.Items.Clear();
                //FinalSymbol.Clear();

                string[] tmptxt1 = txtfile.Split('$');
                foreach (var a in tmptxt1)
                {
                    string[] tmptxt2 = a.Split('!');
                    Symbols tmpsymb = new Symbols(tmptxt2[0], tmptxt2[1]);
                    if (!FinalSymbol.Contains(tmpsymb))
                    {
                        lstFinalSymbol.Items.Add(tmpsymb);
                        lstFinalSymbol.ValueMember = "InsCode";
                        lstFinalSymbol.DisplayMember = "Symbol";
                        lstFinalSymbol.SelectedIndex = lstFinalSymbol.Items.Count - 1;
                        FinalSymbol.Add(tmpsymb);
                    }
                }
            }
            SymbolCounter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string txtfile = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                foreach (Symbols a in FinalSymbol)
                {
                    txtfile += a.Symbol + "!" + a.InsCode + "$";
                }
                txtfile = txtfile.Substring(0, txtfile.Count() - 1);

                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtfile);

            }
        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            try
            {
                Scope = cmbScop.Text;
                SDEven = txtSDEven.Text;
                SHEven = txtSHEven.Text;
                EDEven = txtDEven.Text;
                EHEven = txtHEven.Text;
                NetworkAddress = txtNAdd.Text;
                InitialCash = Convert.ToDouble(txtInitialCash.Text);
                dgAllSymbols.Rows.Clear();
                dgSymbolsSummary.Rows.Clear();


                dgAllSymbols.Columns.Clear();
                dgSymbolsSummary.Columns.Clear();


                SymbKeys = new Dictionary<string, int>();

                int KeyNum = 1;
                dgAllSymbols.Columns.Add("cdgDEven", "DEven");
                dgAllSymbols.Columns.Add("cdgHEven", "HEven");                
                dgAllSymbols.Columns.Add("cdgCash", "نقد");
                dgSymbolsSummary.Columns.Add("cdgDEven", "DEven");
                dgSymbolsSummary.Columns.Add("cdgHEven", "HEven");
                foreach (var a in FinalSymbol)
                {
                    dgAllSymbols.Columns.Add("cdg" + a.Symbol, a.Symbol);
                    dgAllSymbols.Columns.Add("cdgNS" + a.Symbol, "NSG_" + a.Symbol[0] + a.Symbol[1]);
                    dgSymbolsSummary.Columns.Add("cdg" + a.Symbol, a.Symbol);
                    SymbKeys.Add(a.InsCode, KeyNum);
                    KeyNum++;
                    
                    chart1.Series.Add(a.InsCode);
                    chart1.Series[a.InsCode].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series[a.InsCode].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                }
                btnOptimize.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
                //BackTesting(DataLoader());
            }
            catch (Exception e1)
            {
                ;
            }
        }

        private DataTable DataLoader()
        {
            try{
            mySql = new sqlInterface(Properties.Settings.Default.sqlserver, "TseTrade",
                                      Properties.Settings.Default.username, Properties.Settings.Default.pass);


            sqlCmd = "SELECT T.DEVEN, T.HEven, T.InsCode, T.PriceAvg, (SELECT AVG(W1.[Return]) FROM ( SELECT TOP (20) W.[Return] FROM TseTrade.dbo.TsePriceCandles W WHERE W.InsCode = T.InsCode AND W.Periodicity = " + Scope + "  AND ((W.DEven=T.DEven AND W.HEven<=T.HEven) OR (W.DEven<T.DEven)) ORDER BY W.DEven DESC, W.HEven DESC)W1 ) [Return] FROM TseTrade.dbo.TsePriceCandles T WHERE T.InsCode in (";

            foreach (var a in FinalSymbol)
            {
                sqlCmd += a.InsCode + ", ";
            }            
            sqlCmd = sqlCmd.Substring(0, sqlCmd.Length - 2);

            sqlCmd += ") AND T.Periodicity = " + Scope + "  AND ((T.DEven=" + EDEven + " AND T.HEven<=" + EHEven + ") OR (T.DEven<" + EDEven + ")) AND ((T.DEven=" + SDEven + " AND T.HEven>=" + SHEven + ") OR (T.DEven>" + SDEven + ")) ORDER BY T.DEven, T.HEven, T.InsCode";

            DataTable TimeTrend = new DataTable();
            TimeTrend = mySql.SqlExecuteReader(sqlCmd);

            return TimeTrend;
            }
            catch (Exception e1)
            {
                ;
                return null;
            }
        }

        private void BackTesting(DataTable TimeTrend)
        {
            
            int CurHEven = Convert.ToInt32(TimeTrend.Rows[0]["HEven"]);
            int PerNum = 0;
            int SC = FinalSymbol.Count + 1;
            DataTable SignalData = new DataTable();
            double[] AdjRet = new double[FinalSymbol.Count + 1];
            double[] CurW = new double[FinalSymbol.Count + 1];
            double[] CurValue = new double[FinalSymbol.Count + 1];
            double CurCash = Convert.ToDouble(txtInitialCash.Text);
            double PortfolioValue = 0;

            Dictionary<Symbols, double[]> BestLimitDic = new Dictionary<Symbols, double[]>();

            int[] CurShares = new int[SC];
            CurW[0] = 1.0;
            CurValue[0] = CurCash;
            PortfolioValue = CurCash;
            int TTrendInd = 0;

            var CurPrice = new Dictionary<string, double>();
            var HistAdjRet = new Dictionary<string, List<NeuralNetworkRes>>();

            double[][] VarCov = new double[FinalSymbol.Count + 1][];
            Symbols CurSymb;
            int KInd = 0;
            int AllRows = TimeTrend.Rows.Count;
            double TransCost = 0;
             try
                {
                foreach (DataRow a in TimeTrend.Rows)
                {
                    CurSymb = (Symbols)FinalSymbol.Find(x => x.InsCode == a["InsCode"].ToString());


                    if (a["HEven"].ToString() != CurHEven.ToString() || PerNum == 0)
                    {
                        PerNum++;
                        AdjRet = new double[SC];
                        AdjRet[0] = CashAdjRet;
                        HistAdjRet = new Dictionary<string, List<NeuralNetworkRes>>();
                        VarCov = new double[SC][];
                        HistAdjRet = HistComputer(FinalSymbol, a["DEven"].ToString(), a["HEven"].ToString());
                        VarCov = VarCov_Calculator(HistAdjRet);
                        //Create new FinalSymbol for Optimization and new AdjRet and VarCov
                    }

                    CurHEven = Convert.ToInt32(a["HEven"]);

                    mySql = new sqlInterface(Properties.Settings.Default.sqlserver, "TseTrade",
                                              Properties.Settings.Default.username, Properties.Settings.Default.pass);

                    //string StrCmd = "DECLARE @InsCode bigint = " + a["InsCode"] + " DECLARE @Max_Row_Count int = " + 40 + " DECLARE @SDEven int DECLARE @SHEven int = 90000 DECLARE @EDEven int = " + a["DEven"].ToString() + " DECLARE @EHEven int = " + a["HEven"].ToString() + " DECLARE @Periodicity int = " + Scope + " DECLARE @MPeriod int = 5  DECLARE @TT int = 1 SET @SDEven = (SELECT TseTrade.dbo.fn_Max_RowCount_ToDEven(@InsCode, @Periodicity, @EDEven, @EHEven, @Max_Row_Count)) ";

                    //sqlCmd = StrCmd + System.IO.File.ReadAllText("Query1.txt");

                    sqlCmd = string.Format(@"SELECT *  FROM AdjPrice.dbo.TempPriceData T WHERE T.InsCode = {0}  AND T.DEven={1} AND T.HEven={2} ORDER BY T.DEven, T.HEven",a["InsCode"].ToString(),a["DEven"].ToString(), a["HEven"].ToString());

                    SignalData = mySql.SqlExecuteReader(sqlCmd);



                    double[] NeuralInput = new double[InputLayerDataCount];
                    FIFO[] FList = new FIFO[20];

                    //Return                    
                    NeuralInput[0] = Convert.ToDouble(a["Return"]);

                    for (int s = 0; s < 21; s++)
                    {
                        if (SignalData.Rows[0][s + 3].ToString() != "")
                            NeuralInput[s] = Convert.ToDouble(SignalData.Rows[0][s + 3]);
                    }

                    F_Item NN;
                    for (int s = 21; s < InputLayerDataCount; s++)
                    {
                        FList[s - 21] = new FIFO(5);
                        NN = new F_Item();
                        if (SignalData.Rows[0][s + 3].ToString() != "")
                            NN.NNO = Convert.ToDouble(SignalData.Rows[0][s + 3]);
                        FList[s - 21].Push(NN);
                        NeuralInput[s] = FList[s - 21].GetMeanValue();
                    }

                    double tmpSg = NeuralComputer(CurSymb, NeuralInput);
                    AdjRet[SymbKeys[CurSymb.InsCode]] = tmpSg;


                    if (TTrendInd == TimeTrend.Rows.Count - 1 || TimeTrend.Rows[TTrendInd + 1]["HEven"].ToString() != CurHEven.ToString())
                    {
                        //Get price
                        sqlCmd = "SELECT * FROM ( SELECT ROW_NUMBER() OVER ( PARTITION BY InsCode ORDER BY DEven DESC, HEven DESC ) Rn, T.InsCode, T.PriceAvg Price FROM TseTrade.dbo.TsePriceCandles T WHERE InsCode in (";
                        foreach (var a1 in FinalSymbol)
                        {
                            sqlCmd += a1.InsCode + ", ";
                        }
                        sqlCmd = sqlCmd.Substring(0, sqlCmd.Length - 2);
                        sqlCmd += ") AND ( (DEven= " + a["DEven"].ToString() + "  AND HEven<= " + a["HEven"].ToString() + ") OR (DEven < " + a["DEven"].ToString() + ") ) AND Periodicity=" + Scope + " ) K WHERE K.RN = 1";
                        DataTable Prices = new DataTable();
                        Prices = mySql.SqlExecuteReader(sqlCmd);

                        CurPrice.Clear();
                        foreach (DataRow a1 in Prices.Rows)
                        {
                            CurPrice.Add(a1["InsCode"].ToString(), double.Parse(a1["Price"].ToString()));
                        }


                        double[] NewW = new double[SC];
                        NewW = Optimizer_Function(CurW, AdjRet, FinalSymbol, VarCov);



                        double[] NewValue = new double[SC];


                        string[] Date = new string[2] { a["DEven"].ToString(), a["HEven"].ToString() };
                        if (Date[0] == "20130707" && Date[1] == "112000")
                        {
                            ;
                        }
                        double[] DiffW = new double[SC];


                        for (int k = 0; k < SC; k++)
                        {
                            DiffW[k] = NewW[k] - CurW[k];
                        }


                        //CurW = NewW;
                        int[] Shares = new int[SC];

                        double tmpCash = CurCash;
                        BestLimitDic.Clear();
                        for (int i = 1; i < SC; i++)
                        {
                            DataTable BestLimits = mySql.SqlExecuteReader(@"SELECT * FROM TseTrade.dbo.fn_AT_IND_BestLimits(" + FinalSymbol[i - 1].InsCode.ToString() + "," + a["DEven"].ToString() + ", " + a["HEven"].ToString() + ") K");
                            double[] Limits = new double[4];
                            for(int s=0; s<4; s++) Limits[s] = Convert.ToDouble(BestLimits.Rows[0][s + 3].ToString());
                            BestLimitDic.Add(FinalSymbol[i - 1], Limits);

                            if (Math.Round(DiffW[i], 4) > 0)
                            {
                                /*double MoneytoBuy = Math.Min(PortfolioValue * Math.Round(DiffW[i], 4), tmpCash) * 0.995;
                                int tmpsh = (int)Math.Floor(MoneytoBuy / Convert.ToDouble(BestLimits.Rows[0]["PMeOf"].ToString()));
                                tmpsh = (int)Math.Min(tmpsh,Convert.ToDouble(BestLimits.Rows[0]["QTitMeOf"].ToString()));
                                CurShares[i] += tmpsh;
                                TransCost += 0.005 * tmpsh * Convert.ToDouble(BestLimits.Rows[0]["PMeOf"].ToString());

                                tmpCash -= 1.005 * tmpsh * Convert.ToDouble(BestLimits.Rows[0]["PMeOf"].ToString());*/

                                double MoneytoBuy = Math.Min(PortfolioValue * Math.Round(DiffW[i], 4), tmpCash) * (1-BuyCost);
                                int tmpsh = (int)Math.Floor(MoneytoBuy / CurPrice[FinalSymbol[i - 1].InsCode]);
                                //tmpsh = (int)Math.Min(tmpsh, Convert.ToDouble(BestLimits.Rows[0]["QTitMeOf"].ToString()));
                                CurShares[i] += tmpsh;
                                TransCost += BuyCost * tmpsh * CurPrice[FinalSymbol[i - 1].InsCode]; //Convert.ToDouble(BestLimits.Rows[0]["PMeOf"].ToString());

                                tmpCash -= (1+BuyCost) * tmpsh * CurPrice[FinalSymbol[i - 1].InsCode];
                            }
                            else if (Math.Round(DiffW[i], 4) < 0)
                            {
                                /*double MoneytoSell = PortfolioValue * Math.Round(Math.Abs(DiffW[i]), 4) * 1.01;
                                int tmpsh = Math.Min((int)Math.Ceiling(MoneytoSell / Convert.ToDouble(BestLimits.Rows[0]["PMeDem"].ToString())), CurShares[i]);
                                tmpsh = (int)Math.Min(tmpsh, Convert.ToDouble(BestLimits.Rows[0]["QTitMeDem"].ToString()));
                                CurShares[i] -= tmpsh;
                                TransCost += 0.01 * tmpsh * Convert.ToDouble(BestLimits.Rows[0]["PMeDem"].ToString());
                                tmpCash += 0.99 * tmpsh * Convert.ToDouble(BestLimits.Rows[0]["PMeDem"].ToString());*/

                                double MoneytoSell = PortfolioValue * Math.Round(Math.Abs(DiffW[i]), 4) * (1 + SellCost);
                                int tmpsh = Math.Min((int)Math.Ceiling(MoneytoSell / CurPrice[FinalSymbol[i - 1].InsCode]), CurShares[i]);
                                //tmpsh = (int)Math.Min(tmpsh, Convert.ToDouble(BestLimits.Rows[0]["QTitMeDem"].ToString()));
                                CurShares[i] -= tmpsh;
                                TransCost += (SellCost) * tmpsh * CurPrice[FinalSymbol[i - 1].InsCode];
                                tmpCash += (1 - SellCost) * tmpsh * CurPrice[FinalSymbol[i - 1].InsCode];
                            }
                        }
                        CurCash = tmpCash;// *1.003;
                        
                        PortfolioValue = CurCash;
                        for (int k = 1; k < SC; k++)
                        {                            
                            PortfolioValue += CurShares[k] * CurPrice[FinalSymbol[k - 1].InsCode];
                        }

                        CurW[0] = CurCash / PortfolioValue;
                        for (int k = 1; k < SC; k++) CurW[k] = CurShares[k] * CurPrice[FinalSymbol[k - 1].InsCode] / PortfolioValue;

                        backgroundWorker1.ReportProgress((int)(KInd / AllRows), new OptResults(Date, CurW, CurCash, CurShares, PortfolioValue, CurPrice, AdjRet,TransCost));

                        //Trade!!!
                        //Modified NewW

                    }

                    TTrendInd++;
                }



            }
            catch (Exception e1)
            {
                if (e1.Message.Contains("singular"))
                {
                    int ww = VarCov[0].Count();
                    double[,] Xvar = new double[ww, ww];
                    for (int i1 = 0; i1 < ww; i1++)
                    {
                        for (int i2 = 0; i2 < ww; i2++)
                        {
                            Xvar[i1, i2] = VarCov[i1][i2];
                        }
                    }
                    double sd = Matrix.Determinant(Xvar);
                    double [,] KK = Matrix.Inverse(Xvar);
                }
            }
        }
        

        private Dictionary<string, List<NeuralNetworkRes>> HistComputer(List<Symbols> mySymbol, string myDEven, string myHEven)
        {
            try
            {
                Dictionary<string, List<NeuralNetworkRes>> RetTable = new Dictionary<string, List<NeuralNetworkRes>>();
                foreach (var a in mySymbol)
                {   
                    mySql = new sqlInterface(Properties.Settings.Default.sqlserver, "TseTrade",
                                                  Properties.Settings.Default.username, Properties.Settings.Default.pass);

                    //sqlCmd = "DECLARE @InsCode bigint = " + a.InsCode + " DECLARE @Max_Row_Count int = " + 40 + " DECLARE @SDEven int DECLARE @SHEven int = 90000 DECLARE @EDEven int = " + myDEven + " DECLARE @EHEven int = " + myHEven + " DECLARE @Periodicity int = " + Scope + " DECLARE @MPeriod int = 5 DECLARE @TT int = 100 SET @SDEven = (SELECT TseTrade.dbo.fn_Max_RowCount_ToDEven(@InsCode, @Periodicity, @EDEven, @EHEven, @Max_Row_Count)) ";
                    //sqlCmd = sqlCmd + System.IO.File.ReadAllText("Query1.txt");

                    sqlCmd = string.Format(@"SELECT Top(100) T.*  FROM AdjPrice.dbo.TempPriceData T WHERE T.InsCode = {0} AND ((T.DEven={1} AND T.HEven<={2}) OR (T.DEven<{3})) ORDER BY T.DEven DESC, T.HEven DESC", a.InsCode.ToString(),myDEven, myHEven, myDEven);
                    DataTable tmpDatatable = mySql.SqlExecuteReader(sqlCmd);

                    double[] NeuralInput = new double[InputLayerDataCount];
                    FIFO[] FList = new FIFO[20];
                    
                    List<NeuralNetworkRes> ListNNR = new List<NeuralNetworkRes>();
                    foreach (DataRow b in tmpDatatable.Rows)
                    {                        
                        for (int s = 0; s < 21; s++)
                        {
                            if (b[s + 3].ToString() != "")
                                NeuralInput[s] = Convert.ToDouble(b[s + 3]);
                        }

                        F_Item NN;
                        for (int s = 21; s < InputLayerDataCount; s++)
                        {
                            FList[s - 21] = new FIFO(5);
                            NN = new F_Item();
                            if (b[s + 3].ToString() != "")
                                NN.NNO = Convert.ToDouble(b[s + 3]);
                            FList[s - 21].Push(NN);
                            NeuralInput[s] = FList[s - 21].GetMeanValue();
                        }
                        NeuralNetworkRes NNR = new NeuralNetworkRes(b["DEven"].ToString(), b["HEven"].ToString(), NeuralComputer(a, NeuralInput));
                        ListNNR.Add(NNR);
                    }
                    RetTable.Add(a.InsCode, ListNNR);
                }

                return RetTable;
            }
            catch (Exception e)
            {
                ;
                return null;
            }
        }

        private double NeuralComputer(Symbols mySymbol, double[] mySignals)
        {
            double ResSignal = 0;
            Neural_Network NN = new Neural_Network();
            if (System.IO.File.Exists(NetworkAddress + "\\" + mySymbol.InsCode))
            {
                NN = Serializer.DeserializeNeuralNetwork(NetworkAddress + "\\" + mySymbol.InsCode);
                ResSignal = NN.Network.Compute(mySignals)[0] * (1 - NN.TestError) / 25.0;
                return ResSignal;
            }
            else
                return 0;
        }

        private double [] Optimizer_Function(double [] PreW, double [] myRet, List<Symbols> mySymbols, double [][] myVarCov)
        {            
            Cplex_Optimizer Opt = new Cplex_Optimizer();
            Opt.PreW = PreW;
            Opt.myRet = myRet;
            Opt.mySymbols = mySymbols;
            Opt.VarCov = myVarCov;
            Opt.ExpVar = ExpectedVar;
            double[] Res = Opt.Run_Opt_Extreme();
            return Res;
        }

        private double [][] VarCov_Calculator(Dictionary<string, List<NeuralNetworkRes>> myNeuralRes)
        {
            int SymbCount = myNeuralRes.Keys.Count();
            double[][] RetVarCov = new double[SymbCount + 1][];

            int i=1; int j=1;
            RetVarCov[0] = new double[SymbCount + 1];
            RetVarCov[0][0] = 0.001;
            
            foreach (var a in myNeuralRes)
            {
                RetVarCov[i] = new double[SymbCount + 1];
                List<NeuralNetworkRes> tmp1 = new List<NeuralNetworkRes>();
                tmp1 = a.Value;
                j = 1;
                foreach (var b in myNeuralRes)
                {
                    List<NeuralNetworkRes> tmp2 = new List<NeuralNetworkRes>();
                    tmp2 = b.Value;
                    double tmpsum2 = tmp2.Sum(x => x.NF) / tmp2.Count;

                    var list3 = (from Item1 in tmp1
                                 join Item2 in tmp2
                                 on 
                                 new { 
                                        JoinProperty1 = Item1.DEven,
                                        JoinProperty2 = Item1.HEven
                                    } 
                                equals 
                                new {
                                        JoinProperty1 = Item2.DEven,
                                        JoinProperty2 = Item2.HEven
                                    }
                                 //into grouping
                                 //from Item2 in grouping.DefaultIfEmpty()
                                 select new { Item1, Item2 }).ToList();
                    var w = list3.Sum(x => (x.Item1.NF-list3.Average(z=> z.Item1.NF))*(x.Item2.NF - list3.Average(z=> z.Item2.NF)))/list3.Count;

                    if (w.ToString() == "NaN")
                    {
                        RetVarCov[i][j] = 0;
                    }
                    else
                    {
                        RetVarCov[i][j] = Convert.ToDouble(w);
                    }
                    if (i == j && RetVarCov[i][j] == 0)
                    {
                        for(int k=0; k<SymbCount + 1; k++)
                            RetVarCov[i][k] = 1;
                    }
                    j++;
                }
                i++;
            }

            

            return RetVarCov;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackTesting(DataLoader());
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Application.DoEvents();

            OptResults Res = (OptResults)e.UserState;
            
            object[] Row = new object[2*Res.Weights.Count() + 2];
            Row[0] = Res.DEven;
            Row[1] = Res.HEven;            
            Row[2] = Math.Round(Res.Cash);
            for (int i = 1; i < Res.Weights.Count(); i++)
            {
                Row[1 + 2 * i] = Res.Shares[i];
                Row[2 + 2 * i] = Math.Round(Res.AdjRet[i],5);
            }
            dgAllSymbols.Rows.Add(Row);
            dgAllSymbols.FirstDisplayedScrollingRowIndex = dgAllSymbols.Rows.Count - 1;

            Row = new object[Res.Weights.Count() + 1];
            Row[0] = Res.DEven;
            Row[1] = Res.HEven;
            int q = 2;
            foreach (var a in FinalSymbol)
            {
                if (Res.CurPrice!= null && Res.CurPrice.Count > 0)
                {
                    Row[q] = Res.CurPrice[a.InsCode];
                    chart1.Series[a.InsCode].Points.Add(Res.CurPrice[a.InsCode]);
                    q++;
                }
            }

            dgSymbolsSummary.Rows.Add(Row);
            dgSymbolsSummary.FirstDisplayedScrollingRowIndex = dgSymbolsSummary.Rows.Count - 1;

            chart1.Series[0].Points.Add(Res.PortfolioValue);

            

            SetText(txtCurentCash, Math.Round(Res.PortfolioValue).ToString());
            SetText(txtprofit,((Res.PortfolioValue/InitialCash - 1)*100).ToString());
            SetText(txtTransCost, Math.Round(Res.TransCost,2).ToString());
            SetText(txtsum, (Math.Round(Res.TransCost, 2) + Math.Round(Res.PortfolioValue)).ToString());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOptimize.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Indicator newIndicator;
            var f = new FormSelectDecisionMaker();

            if (f.ShowDialog() == DialogResult.OK)
            {
                newIndicator = f.getResult();

            }
            else
            {
                newIndicator = new Indicator("", new List<Parameter> { new Parameter(1, "Fast Window", 20), new Parameter(2, "Slow Window", 50) });
                newIndicator.InsCode = FinalSymbol[0].InsCode;
                newIndicator.EDEven = int.Parse(txtDEven.Text);
                newIndicator.EHEven = int.Parse(txtHEven.Text);
                newIndicator.SDEven = int.Parse(txtSDEven.Text);
                newIndicator.SHEven = int.Parse(txtSHEven.Text);
                newIndicator.MPeriod = int.Parse(txtMPeriod.Text);
                newIndicator.Scope = int.Parse(Scope);
            }

            ProfitFunction PF = new ProfitFunction();
            PF.Cash = 100000000;
            
            double Profit = PF.ProfitFunctionT(newIndicator.getQuery());
            txtprofit.Text = Profit.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        public void ReinforcementLearning(DataTable TimeTrend)
        {
            Actions = new double[] { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 };
            int CurHEven = Convert.ToInt32(TimeTrend.Rows[0]["HEven"]);
            
            Dictionary<RRLInput, StatesValue> RRLNetwork = new Dictionary<RRLInput, StatesValue>();
            
            int PerNum = 0;
            int SC = FinalSymbol.Count + 1;
            DataTable SignalData = new DataTable();            
            double CurCash = Convert.ToDouble(txtInitialCash.Text);
            double PortfolioValue = 0;
            double ObjectivFunction = 0;
            int[] CurShares = new int[SC];           
            PortfolioValue = CurCash;
            ObjectivFunction = PortfolioValue;
            Dictionary<Symbols, int> SymbolIndex = new Dictionary<Symbols, int>();

            
            Symbols CurSymb;
            int TTrendInd = 0;
            double TransCost = 0;

            
            try
            {
                while (1 == 1)
                {
                    Dictionary<Symbols, StockProperties> CurPrice = new Dictionary<Symbols, StockProperties>();
                    List<EachStep> TotalSteps = new List<EachStep>();
                    List<StatesValue> TotalStates = new List<StatesValue>();
                    List<double[]> TotalActionsSequenc = new List<double[]>();
                    double[] EachStepAction = new double[SC];
                    double[] CurStepWeights = new double[SC];
                    double[] PrevStepWeights = new double[SC];
                    PerNum = 0;

                    foreach (DataRow a in TimeTrend.Rows)
                    {
                        CurSymb = (Symbols)FinalSymbol.Find(x => x.InsCode == a["InsCode"].ToString());
                        if (a["HEven"].ToString() != CurHEven.ToString() || PerNum == 0)
                        {
                            PerNum++;
                            TotalStates = new List<StatesValue>();
                            EachStepAction = new double[SC];
                            CurStepWeights = new double[SC];
                        }

                        CurHEven = Convert.ToInt32(a["HEven"]);

                        mySql = new sqlInterface(Properties.Settings.Default.sqlserver, "TseTrade",
                                                  Properties.Settings.Default.username, Properties.Settings.Default.pass);

                        string StrCmd = "DECLARE @InsCode bigint = " + a["InsCode"] + " DECLARE @Max_Row_Count int = " + 40 + " DECLARE @SDEven int DECLARE @SHEven int = 90000 DECLARE @EDEven int = " + a["DEven"].ToString() + " DECLARE @EHEven int = " + a["HEven"].ToString() + " DECLARE @Periodicity int = " + Scope + " DECLARE @MPeriod int = 5  DECLARE @TT int = 1 SET @SDEven = (SELECT TseTrade.dbo.fn_Max_RowCount_ToDEven(@InsCode, @Periodicity, @EDEven, @EHEven, @Max_Row_Count)) ";

                        sqlCmd = StrCmd + System.IO.File.ReadAllText("Query1.txt");

                        SignalData = mySql.SqlExecuteReader(sqlCmd);

                        //States
                        double[] IStates = new double[InputLayerDataCount];

                        for (int s = 0; s < InputLayerDataCount; s++)//Should be edit
                        {
                            if (SignalData.Rows[0][s + 2].ToString() != "")
                                IStates[s] = Convert.ToDouble(SignalData.Rows[0][s + 2]);
                        }

                        RRLInput tmpInput = new RRLInput(CurSymb, IStates);

                        if (RRLNetwork.ContainsKey(tmpInput))
                        {
                            //Action Selection Strategy
                            int SelectedAction = ActionSelection(RRLNetwork[tmpInput].ValueArray);
                            EachStepAction[SymbolIndex[CurSymb]] = Actions[SelectedAction];
                        }
                        else
                        {
                            StatesValue tmpStates = new StatesValue(CurSymb, IStates, Actions, InitialRandomValues(InputLayerDataCount));
                            EachStepAction[SymbolIndex[CurSymb]] = Actions[ActionSelection(tmpStates.ValueArray)];
                            RRLNetwork.Add(tmpInput, tmpStates);
                        }

                        TotalStates.Add(new StatesValue(CurSymb, IStates, Actions, RRLNetwork[tmpInput].ValueArray));



                        if (TTrendInd == TimeTrend.Rows.Count - 1 || TimeTrend.Rows[TTrendInd + 1]["HEven"].ToString() != CurHEven.ToString())
                        {
                            TotalActionsSequenc.Add(EachStepAction);

                            //Get price
                            sqlCmd = "SELECT * FROM ( SELECT ROW_NUMBER() OVER ( PARTITION BY InsCode ORDER BY DEven DESC, HEven DESC ) Rn, T.InsCode, T.PriceAvg Price FROM TseTrade.dbo.TsePriceCandles T WHERE InsCode in (";
                            foreach (var a1 in FinalSymbol)
                            {
                                sqlCmd += a1.InsCode + ", ";
                            }
                            sqlCmd = sqlCmd.Substring(0, sqlCmd.Length - 2);
                            sqlCmd += ") AND ( (DEven= " + a["DEven"].ToString() + "  AND HEven<= " + a["HEven"].ToString() + ") OR (DEven < " + a["DEven"].ToString() + ") ) AND Periodicity=" + Scope + " ) K WHERE K.RN = 1";
                            DataTable Prices = new DataTable();
                            Prices = mySql.SqlExecuteReader(sqlCmd);

                            CurPrice.Clear();
                            foreach (DataRow a1 in Prices.Rows)
                            {
                                CurPrice.Add(FinalSymbol.First(x => x.InsCode == a1["InsCode"].ToString()), new StockProperties(double.Parse(a1["Price"].ToString()), double.Parse(a1["Mean"].ToString()), double.Parse(a1["Var"].ToString())));
                            }


                            double SumValue = EachStepAction.Sum();
                            CurStepWeights = EachStepAction.Select(x => x / SumValue).ToArray();

                            double[] WeightDiff = new double[FinalSymbol.Count];

                            for (int i = 0; i < FinalSymbol.Count; i++)
                            {
                                WeightDiff[i] = CurStepWeights[i] - PrevStepWeights[i];
                            }


                            int[] Shares = new int[SC];

                            double tmpCash = CurCash;
                            double tmpVaR = 0;

                            for (int i = 1; i < SC; i++)
                            {
                                if (Math.Round(WeightDiff[i], 2) > 0)
                                {
                                    double MoneytoBuy = Math.Min(PortfolioValue * Math.Round(WeightDiff[i], 2), tmpCash) * 0.995;
                                    int tmpsh = (int)Math.Floor(MoneytoBuy / CurPrice[FinalSymbol[i - 1]].Price);
                                    CurShares[i] += tmpsh;
                                    TransCost += 0.005 * Math.Min(PortfolioValue * Math.Round(WeightDiff[i], 2), tmpCash);
                                    tmpCash -= tmpsh * CurPrice[FinalSymbol[i - 1]].Price + 0.005 * Math.Min(PortfolioValue * Math.Round(WeightDiff[i], 2), tmpCash);

                                }
                                else if (Math.Round(WeightDiff[i], 2) < 0)
                                {
                                    double MoneytoSell = PortfolioValue * Math.Round(Math.Abs(WeightDiff[i]), 2) * 1.01;
                                    int tmpsh = Math.Min((int)Math.Ceiling(MoneytoSell / CurPrice[FinalSymbol[i - 1]].Price), CurShares[i]);
                                    CurShares[i] -= tmpsh;
                                    TransCost += 0.01 * PortfolioValue * Math.Round(Math.Abs(WeightDiff[i]), 2);
                                    tmpCash += tmpsh * CurPrice[FinalSymbol[i - 1]].Price - 0.01 * PortfolioValue * Math.Round(Math.Abs(WeightDiff[i]), 2);

                                }

                            }
                            CurCash = tmpCash;// *1.003;
                            CurStepWeights.CopyTo(PrevStepWeights, 0);

                            double VarCov = Var_Cov_Calculator(FinalSymbol, a["DEven"].ToString(), a["HEven"].ToString(), WeightDiff, RiskAversion);

                            PortfolioValue = 0;
                            for (int k = 1; k < SC; k++)
                            {
                                PortfolioValue += CurShares[k] * CurPrice[FinalSymbol[k - 1]].Price;
                            }
                            ObjectivFunction = PortfolioValue * (1 - VarCov) + CurCash;

                            TotalSteps.Add(new EachStep(TotalStates, ObjectivFunction));
                        }


                        TTrendInd++;
                    }

                    double reward = ObjectivFunction / InitialCash - 1;
                    int w = 0;
                    foreach (var k in TotalActionsSequenc)
                    {
                        for (int q = 1; q < SC; q++)
                        {
                            if (TotalSteps[w].CurStates.First(x => x.Symbol == FinalSymbol[q - 1]) != null)
                                TotalSteps[w].CurStates.First(x => x.Symbol == FinalSymbol[q - 1]).ValueArray[Convert.ToInt16(k[q] * 10)] = reward * (w / TotalActionsSequenc.Count);
                        }
                        w++;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public double[] InitialRandomValues(int InputNumber)
        {
            double[] kk = new double[InputNumber];
            for (int i = 0; i < InputNumber; i++)
            {
                kk[i] = RandomGenerator.NextDouble();
            }
            return kk;
        }

        public double Var_Cov_Calculator(List<Symbols> mySymb, string myDEven, string myHEven, double[] myWeight, double RiskAvers)
        {
            double[][] RetVarCov = new double[mySymb.Count + 1][];
            int i = 0;
            int j = 0;
            for (i = 1; i < mySymb.Count + 1; i++)
            {
                RetVarCov[i] = new double[mySymb.Count + 1];
                for (j = 1; j < mySymb.Count + 1; j++)
                {
                    sqlCmd = string.Format(@"SELECT TseTrade.dbo.fn_Covariance({0},{1},{2},(SELECT TseTrade.dbo.fn_Max_RowCount_ToDEven({0}, {2}, {3}, {4}, 50)),9000,{5},{6})", mySymb[i].InsCode, mySymb[j].InsCode, Scope, myDEven, myHEven);
                    RetVarCov[i][j] = double.Parse(mySql.SqlExecuteReader(sqlCmd).Rows[0][0].ToString());
                    j++;
                }
                i++;
            }

            double[] tmptmp = new double[mySymb.Count + 1];
            for (i = 0; i < mySymb.Count + 1; i++)
            {
                tmptmp[i] = RetVarCov[i].InnerProduct(myWeight);
            }

            double PortfolioRisk = 0;

            PortfolioRisk = myWeight.InnerProduct(tmptmp);


            return RiskAvers*PortfolioRisk;
        }

        public int ActionSelection(double[] Values)
        {
            List<double> tmpValues = new List<double>();
            tmpValues = Values.ToList();
            double kk = tmpValues.Sum(x=> x);
            Values = tmpValues.Select(x => x / (kk)).OrderBy(x=> x).ToArray();
            int i = 1;
            
            double RVar = RandomGenerator.NextDouble();
            while (i < Values.Count() && RVar > Values[i - 1])
            {
                Values[i] += Values[i - 1];
                i++;
            }

            return i;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = groupBox1.Width + 10;
        }
        

        /*
        private double[][] Matrix_Invertor(double[][] myMatrix)
        {
            double[][] RetMat = new double[myMatrix.Length][];
            double[,] tmpMat = new double[myMatrix.Length, myMatrix.Length];

            for (int i = 0; i < myMatrix.Length; i++)
            {                
                for (int j = 0; j < myMatrix.Length; j++)
                {
                    tmpMat[i, j] = myMatrix[i][j];
                }
            }

            Matrix MM = new Matrix(tmpMat);
            MM = MM.Inverse();

            for (int i = 0; i < myMatrix.Length; i++)
            {
                RetMat[i] = new double[myMatrix.Length];
                for (int j = 0; j < myMatrix.Length; j++)
                {
                    RetMat[i][j] = MM[i, j].Re;
                }
            }

            return RetMat;
        }
        */
    }
    

    public class NeuralNetworkRes
    {
        public string DEven;
        public string HEven;
        public double NF;
        public NeuralNetworkRes(string myDEven, string myHEven, double myNF)
        {
            DEven = myDEven;
            HEven = myHEven;
            NF = myNF;
        }
    }

    public class OptResults
    {
        public string DEven;
        public string HEven;
        public double[] Weights;
        public double Cash;
        public int[] Shares;
        public double PortfolioValue;
        public Dictionary<string, double> CurPrice;
        public double[] AdjRet;
        public double TransCost;
        public OptResults(string[] myDate, double[] myWeights, double myCash, int[] myShares, double myValue, Dictionary<string, double> myCurPrice, double[] myAdjRet, double myTransCost)
        {
            try
            {
                DEven = myDate[0];
                HEven = myDate[1];
                Weights = new double[myWeights.Count()];
                myWeights.CopyTo(Weights, 0);
                AdjRet = new double[myAdjRet.Count()];
                myAdjRet.CopyTo(AdjRet, 0);

                Cash = myCash;
                Shares = new int[myShares.Count()];
                myShares.CopyTo(Shares, 0);

                PortfolioValue = myValue;
                CurPrice = new Dictionary<string, double>();
                foreach (var r in myCurPrice)
                    CurPrice.Add(r.Key, r.Value);

                TransCost = myTransCost;
            }
            catch (Exception e)
            {
                ;
            }
            
        }
    }

    public class StatesValue
    {
        public Symbols Symbol;
        public double[] StateArray;
        public double[] ActionArray;
        public double[] ValueArray;
        public StatesValue(Symbols mySymbol, double[] myState, double[] myAction, double[] myValue)
        {
            Symbol = mySymbol;
            myState.CopyTo(StateArray,0);
            myAction.CopyTo(ActionArray,0);
            myValue.CopyTo(ValueArray, 0);
        }
    }

    public class EachStep
    {
        public List<StatesValue> CurStates;
        public double Profit;
        
        public EachStep(List<StatesValue> myStates, double myProfit)
        {
            CurStates = new List<StatesValue>();
            CurStates = myStates;
            Profit = myProfit;            
        }
    }

    public class StockProperties
    {
        public double Price;
        public double Mean;
        public double Var;
        public StockProperties(double myPrice, double myMean, double myVar)
        {
            Price = myPrice;
            Mean = myMean;
            Var = myVar;
        }
    }

    public class RRLInput
    {
        public Symbols Symbol;
        public double[] InputArray;
        public RRLInput(Symbols mySymbol, double[] myInputArray)
        {
            Symbol = mySymbol;
            InputArray = myInputArray;
        }
    }
}
