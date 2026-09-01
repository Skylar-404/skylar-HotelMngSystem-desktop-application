using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotelmngsystem.Helpers
{
    internal class SortHelper
    {
        private readonly DataGridView dataGridView;
        private readonly HashSet<string> allowedColumns;

        public string SortColumn { get; private set; }
        public string SortDirection { get; private set; } = "ASC";

        public SortHelper(DataGridView dataGridView, IEnumerable<string> allowedColumns, string defaultColumn = "Id")
        {
            this.dataGridView = dataGridView;

            this.allowedColumns = new HashSet<string>(allowedColumns);

            SortColumn = defaultColumn;

            // Click DataGridView header
            dataGridView.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;
        }

        // Header click
        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView.Columns[e.ColumnIndex].Name;
            SortBy(columnName);
        }

        // Sort column
        public void SortBy(string columnName)
        {
            if (!allowedColumns.Contains(columnName))
                return;

            // Same column → ASC / DESC
            if (SortColumn == columnName)
            {
                SortDirection =
                    SortDirection == "ASC"
                        ? "DESC"
                        : "ASC";
            }
            else
            {
                // New column → ASC
                SortColumn = columnName;
                SortDirection = "ASC";
            }

            SortChanged?.Invoke();
        }

        // Display ▲ / ▼
        public void UpdateSortGlyph()
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                // Remove previous arrow
                column.HeaderText =
                    column.HeaderText
                        .Replace(" ▲", "")
                        .Replace(" ▼", "");

                // Disable native glyph
                column.HeaderCell.SortGlyphDirection =
                    SortOrder.None;
            }

            // Add arrow to sorted column
            if (dataGridView.Columns.Contains(SortColumn))
            {
                DataGridViewColumn column =
                    dataGridView.Columns[SortColumn];

                if (SortDirection == "ASC")
                {
                    column.HeaderText += " ▲";
                }
                else
                {
                    column.HeaderText += " ▼";
                }
            }
        }

        // Event
        public event Action SortChanged;
    }
}
