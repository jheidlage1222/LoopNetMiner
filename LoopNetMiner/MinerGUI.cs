using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoopNetMiner
{
    public partial class MinerGUI : Form
    {
        MinerDriver lnMiner = new MinerDriver();
        public MinerGUI()
        {
            InitializeComponent();
        }

        private void btnIntiate_Click(object sender, EventArgs e)
        {
            lnMiner.SearchMine();
        }
    }
}
