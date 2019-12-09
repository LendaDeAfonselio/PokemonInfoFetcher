using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonInfoFetcher;


namespace PokemonInfoWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        #region Ordo.comon
        // some trash India™ 
        #endregion


        #region events
        /// <summary>
        /// Search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            PopulateDatagrid(null);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region private methods

        /// <summary>
        /// Aux method for search button
        /// </summary>
        /// <param name="searchResult"></param>
        private void PopulateDatagrid(object searchResult)
        {
            // Do a for each here and do DataGridview1.<correctMethod>
        }

        #endregion

        
    }
}
