    static class DatagridviewsExt
    {

        public static void ShowRowHeaderNum(this System.Windows.Forms.DataGridView grid, DataGridViewRowPostPaintEventArgs e)
        {
            // Triggered on DGV RowPostPaint
            try
            {
                int rowIdx = (e.RowIndex + 1);

                if (e.RowIndex == grid.NewRowIndex)
                    return;

                StringFormat centerFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                int visibleRowsCount = grid.DisplayedRowCount(true);
                int firstDisplayedRowIndex = grid.FirstDisplayedCell.RowIndex;
                int lastvisibleRowIndex = (firstDisplayedRowIndex + visibleRowsCount) - 1;

                if (e.RowIndex == lastvisibleRowIndex)
                {
                    Size textSize = TextRenderer.MeasureText(rowIdx.ToString(), grid.Font);
                    // If (textSize.Width > grid.RowHeadersWidth)
                    grid.RowHeadersWidth = textSize.Width + 20;
                }

                Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx.ToString(), grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        public static void DirtyCommit(this System.Windows.Forms.DataGridView grid, EventArgs e)
        {
            // Triggered on DGV RowPostPaint
            try
            {
                if (grid.IsCurrentCellDirty)
                {
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit); // If it is dirty, making them commit
                    grid.EndEdit();
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

    }//class
