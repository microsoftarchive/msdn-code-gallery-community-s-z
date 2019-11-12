using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cs_DGV_printing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// structure to hold printed page details
        /// </summary>
        /// <remarks></remarks>
        private struct pageDetails
        {
            public int columns;
            public int rows;
            public int startCol;
            public int startRow;
        }
        /// <summary>
        /// dictionary to hold printed page details, with index key
        /// </summary>
        /// <remarks></remarks>

        private Dictionary<int, pageDetails> pages;
        int maxPagesWide;

        int maxPagesTall;
        /// <summary>
        /// this just loads some text values into the dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridView1.RowHeadersWidth = Convert.ToInt32(DataGridView1.RowHeadersWidth * 1.35);
            for (int r = 1; r <= 100; r++)
            {
                int y = r;
                string fmt = "R{0}C{1}";
                DataGridView1.Rows.Add();
                DataGridView1.Rows[r - 1].SetValues(Enumerable.Range(1, 10).Select(x => string.Format(fmt, y, x)).ToArray());
                DataGridView1.Rows[r - 1].HeaderCell.Value = r.ToString();
            }

        }

        /// <summary>
        /// shows a PrintPreviewDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnPreview_Click(System.Object sender, System.EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = PrintDocument1;
            ppd.WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }

        /// <summary>
        /// starts print job
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            PrintDocument1.Print();
        }

        /// <summary>
        /// the majority of this Sub is calculating printed page ranges
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void PrintDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //'this removes the printed page margins
            PrintDocument1.OriginAtMargins = true;
            PrintDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);

            pages = new Dictionary<int, pageDetails>();

            int maxWidth = Convert.ToInt32(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 40;
            int maxHeight = Convert.ToInt32(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 150 + Label1.Height;

            int pageCounter = 0;
            pages.Add(pageCounter, new pageDetails());

            int columnCounter = 0;

            int columnSum = DataGridView1.RowHeadersWidth;

            for (int c = 0; c <= DataGridView1.Columns.Count - 1; c++)
            {
                if (columnSum + DataGridView1.Columns[c].Width < maxWidth)
                {
                    columnSum += DataGridView1.Columns[c].Width;
                    columnCounter += 1;
                }
                else
                {
                    pages[pageCounter] = new pageDetails
                    {
                        columns = columnCounter,
                        rows = 0,
                        startCol = pages[pageCounter].startCol
                    };
                    columnSum = DataGridView1.RowHeadersWidth + DataGridView1.Columns[c].Width;
                    columnCounter = 1;
                    pageCounter += 1;
                    pages.Add(pageCounter, new pageDetails { startCol = c });
                }
                if (c == DataGridView1.Columns.Count - 1)
                {
                    if (pages[pageCounter].columns == 0)
                    {
                        pages[pageCounter] = new pageDetails
                        {
                            columns = columnCounter,
                            rows = 0,
                            startCol = pages[pageCounter].startCol
                        };
                    }
                }
            }

            maxPagesWide = pages.Keys.Max() + 1;

            pageCounter = 0;

            int rowCounter = 0;

            int rowSum = DataGridView1.ColumnHeadersHeight;

            for (int r = 0; r <= DataGridView1.Rows.Count - 2; r++)
            {
                if (rowSum + DataGridView1.Rows[r].Height < maxHeight)
                {
                    rowSum += DataGridView1.Rows[r].Height;
                    rowCounter += 1;
                }
                else
                {
                    pages[pageCounter] = new pageDetails
                    {
                        columns = pages[pageCounter].columns,
                        rows = rowCounter,
                        startCol = pages[pageCounter].startCol,
                        startRow = pages[pageCounter].startRow
                    };
                    for (int x = 1; x <= maxPagesWide - 1; x++)
                    {
                        pages[pageCounter + x] = new pageDetails
                        {
                            columns = pages[pageCounter + x].columns,
                            rows = rowCounter,
                            startCol = pages[pageCounter + x].startCol,
                            startRow = pages[pageCounter + x].startRow
                        };
                    }

                    pageCounter += maxPagesWide;
                    for (int x = 0; x <= maxPagesWide - 1; x++)
                    {
                        pages.Add(pageCounter + x, new pageDetails
                        {
                            columns = pages[x].columns,
                            rows = 0,
                            startCol = pages[x].startCol,
                            startRow = r
                        });
                    }

                    rowSum = DataGridView1.ColumnHeadersHeight + DataGridView1.Rows[r].Height;
                    rowCounter = 1;
                }
                if (r == DataGridView1.Rows.Count - 2)
                {
                    for (int x = 0; x <= maxPagesWide - 1; x++)
                    {
                        if (pages[pageCounter + x].rows == 0)
                        {
                            pages[pageCounter + x] = new pageDetails
                            {
                                columns = pages[pageCounter + x].columns,
                                rows = rowCounter,
                                startCol = pages[pageCounter + x].startCol,
                                startRow = pages[pageCounter + x].startRow
                            };
                        }
                    }
                }
            }

            maxPagesTall = pages.Count / maxPagesWide;

        }


        int startPage = 0;
        /// <summary>
        /// this is the actual printing routine.
        /// using the pagedetails i calculated earlier, it prints a title,
        /// + as much of the datagridview as will fit on 1 page, then moves to the next page.
        /// this is setup to be dynamic. try resizing the dgv columns or rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void PrintDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle rect = new Rectangle(20, 20, Convert.ToInt32(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Label1.Height);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(Label1.Text, Label1.Font, Brushes.Black, rect, sf);

            sf.Alignment = StringAlignment.Near;

            int startX = 50;
            int startY = rect.Bottom;

            for (int p = startPage; p <= pages.Count - 1; p++)
            {
                Rectangle cell = new Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.ColumnHeadersHeight);
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlLight), cell);
                e.Graphics.DrawRectangle(Pens.Black, cell);

                startY += DataGridView1.ColumnHeadersHeight;

                for (int r = pages[p].startRow; r <= pages[p].startRow + pages[p].rows - 1; r++)
                {
                    cell = new Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.Rows[r].Height);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlLight), cell);
                    e.Graphics.DrawRectangle(Pens.Black, cell);
                    e.Graphics.DrawString(DataGridView1.Rows[r].HeaderCell.Value.ToString(), DataGridView1.Font, Brushes.Black, cell, sf);
                    startY += DataGridView1.Rows[r].Height;
                }

                startX += cell.Width;
                startY = rect.Bottom;

                for (int c = pages[p].startCol; c <= pages[p].startCol + pages[p].columns - 1; c++)
                {
                    cell = new Rectangle(startX, startY, DataGridView1.Columns[c].Width, DataGridView1.ColumnHeadersHeight);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlLight), cell);
                    e.Graphics.DrawRectangle(Pens.Black, cell);
                    e.Graphics.DrawString(DataGridView1.Columns[c].HeaderCell.Value.ToString(), DataGridView1.Font, Brushes.Black, cell, sf);
                    startX += DataGridView1.Columns[c].Width;
                }

                startY = rect.Bottom + DataGridView1.ColumnHeadersHeight;

                for (int r = pages[p].startRow; r <= pages[p].startRow + pages[p].rows - 1; r++)
                {
                    startX = 50 + DataGridView1.RowHeadersWidth;
                    for (int c = pages[p].startCol; c <= pages[p].startCol + pages[p].columns - 1; c++)
                    {
                        cell = new Rectangle(startX, startY, DataGridView1.Columns[c].Width, DataGridView1.Rows[r].Height);
                        e.Graphics.DrawRectangle(Pens.Black, cell);
                        e.Graphics.DrawString(DataGridView1[c, r].Value.ToString(), DataGridView1.Font, Brushes.Black, cell, sf);
                        startX += DataGridView1.Columns[c].Width;
                    }
                    startY += DataGridView1.Rows[r].Height;
                }

                if (p != pages.Count - 1)
                {
                    startPage = p + 1;
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    startPage = 0;
                }

            }

        }

    }
}
