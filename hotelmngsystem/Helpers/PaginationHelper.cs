using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotelmngsystem.Helpers
{
    internal class PaginationHelper
    {
        private readonly FlowLayoutPanel flowPagination;

        private int currentPage = 1;
        private readonly int pageSize;

        private int totalRows;
        private int totalPages;

        public int CurrentPage => currentPage;

        public int PageSize => pageSize;

        public PaginationHelper(FlowLayoutPanel flowPagination, int pageSize = 10)
        {
            this.flowPagination = flowPagination;
            this.pageSize = pageSize;
        }

        public void SetTotalRows(int totalRows)
        {
            this.totalRows = totalRows;

            totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

            if (totalPages == 0)
                totalPages = 1;

            if (currentPage > totalPages)
                currentPage = totalPages;

            CreatePagination();
        }

        private void CreatePagination()
        {
            flowPagination.Controls.Clear();

            // Previous
            Button btnPrevious = new Button
            {
                Text = "< Previous",
                Width = 90,
                Height = 35,
                Enabled = currentPage > 1
            };

            btnPrevious.Click += (sender, e) =>
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    PageChanged?.Invoke(currentPage);
                    CreatePagination();
                }
            };

            flowPagination.Controls.Add(btnPrevious);


            // Page buttons
            for (int i = 1; i <= totalPages; i++)
            {
                Button btnPage = new Button
                {
                    Text = i.ToString(),
                    Width = 40,
                    Height = 35
                };

                int page = i;

                // Current page
                if (page == currentPage)
                {
                    btnPage.BackColor =
                        Color.FromArgb(34, 197, 94);

                    btnPage.ForeColor = Color.White;
                }

                btnPage.Click += (sender, e) =>
                {
                    currentPage = page;

                    PageChanged?.Invoke(currentPage);

                    CreatePagination();
                };

                flowPagination.Controls.Add(btnPage);
            }


            // Next
            Button btnNext = new Button
            {
                Text = "Next >",
                Width = 70,
                Height = 35,
                Enabled = currentPage < totalPages
            };

            btnNext.Click += (sender, e) =>
            {
                if (currentPage < totalPages)
                {
                    currentPage++;

                    PageChanged?.Invoke(currentPage);

                    CreatePagination();
                }
            };

            flowPagination.Controls.Add(btnNext);
        }

        // Event when page changes
        public event Action<int> PageChanged;
    }
}
