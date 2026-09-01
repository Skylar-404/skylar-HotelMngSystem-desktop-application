using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotelmngsystem.Helpers
{
    internal static class DataGridViewHelper
    {
        public static void Configure(DataGridView dataGridView)
        {
            // Header
            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView.ColumnHeadersHeight = 40;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;

            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Header selection
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;


            // Rows
            dataGridView.RowTemplate.Height = 35;

            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightBlue;

            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;


            // Selection
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView.MultiSelect = false;

            dataGridView.ReadOnly = true;

            dataGridView.AllowUserToAddRows = false;


            // Sorting
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }


            // Width
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
